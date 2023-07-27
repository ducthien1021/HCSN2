<template>
    <div
        class="h-container"
        @mousemove="selectedRow = 0"
        @click="hideContextMenu"
        @contextmenu="hideContextMenu"
    >
        <TheNavbar @showTM="showTMDeveloping"></TheNavbar>
        <div class="h-container__right">
            <TheHeader @showTM="showTMDeveloping"></TheHeader>
            <div class="h-page">
                <div class="h-page__toolbar">
                    <div class="h-toolbar__left">
                        <div class="h-toolbar__search">
                            <MISASearch
                                placeholder="Tìm kiếm tài sản"
                                v-model="searchValue"
                            ></MISASearch>
                        </div>
                        <div class="h-toolbar__assettype">
                            <MISADropdown
                                text="Loại tài sản"
                                :dataList="this.$_MISAResources.assetType"
                                :iconLeft="'filter'"
                                :iconRight="'expand'"
                                v-model="typeValue"
                            ></MISADropdown>
                        </div>
                        <div class="h-toolbar__department">
                            <MISADropdown
                                text="Bộ phận sử dụng"
                                :dataList="this.$_MISAResources.department"
                                :iconLeft="'filter'"
                                :iconRight="'expand'"
                                v-model="departmentValue"
                            ></MISADropdown>
                        </div>
                    </div>
                    <div class="h-toolbar__right">
                        <div class="h-toolbar__btn--delet" @click="showTMDeveloping">
                            <MISAButtonSub>
                                <MISAIcon :icon="'delete'"></MISAIcon>
                            </MISAButtonSub>
                        </div>
                        <div class="h-toolbar__btn--excel" @click="showTMDeveloping">
                            <MISAButtonSub>
                                <MISAIcon :icon="'excel'"></MISAIcon>
                            </MISAButtonSub>
                        </div>
                        <div class="h-toolbar__btn--add">
                            <MISAButtonMain :icon="'add--white'" @click="showForm()"
                                >Thêm tài sản</MISAButtonMain
                            >
                        </div>
                    </div>
                </div>
                <div class="h-page__table" @keydown="moveWithKey" tabindex="-1">
                    <div class="h-table__main" ref="tableMain">
                        <table>
                            <thead>
                                <th class="h-column__checkbox">
                                    <input
                                        type="checkbox"
                                        ref="selectAll"
                                        @change="selectAll"
                                        :checked="selectAllStatus"
                                    />
                                </th>
                                <th class="h-column__index">STT</th>
                                <th class="h-column__id">Mã tài sản</th>
                                <th class="h-column__name">Tên tài sản</th>
                                <th class="h-column__type">Loại tài sản</th>
                                <th class="h-column__department">Bộ phận sử dụng</th>
                                <th class="h-column__amount">Số lượng</th>
                                <th class="h-column__originalprice">Nguyên giá</th>
                                <th class="h-column__accumulated">HM/KM luỹ kế</th>
                                <th class="h-column__remaining">Giá trị còn lại</th>
                                <th class="h-column__tool">Chức năng</th>
                            </thead>
                            <tbody>
                                <tr
                                    v-for="(item, index) in assetsListShown"
                                    :key="item.AssetID"
                                    @dblclick="showForm(item.AssetID)"
                                    @click="selectItem(item.AssetID)"
                                    @contextmenu="showContextMenu(item.AssetID)"
                                    :class="index + 1 == selectedRow ? 'h-row--selected' : ''"
                                >
                                    <td class="h-column__checkbox" @dblclick="stopPropagation">
                                        <input
                                            type="checkbox"
                                            ref="checkbox"
                                            :checked="selectedItem[item.AssetID]"
                                        />
                                    </td>
                                    <td class="h-column__index">{{ index + 1 }}</td>
                                    <td class="h-column__id">{{ item.AssetID }}</td>
                                    <td class="h-column__name">{{ item.Name }}</td>
                                    <td class="h-column__type">{{ item.Type }}</td>
                                    <td class="h-column__department">{{ item.Department }}</td>
                                    <td class="h-column__amount">
                                        {{ numberHandler(item.Amount) }}
                                    </td>
                                    <td class="h-column__originalprice">
                                        {{ numberHandler(item.TheOriginalPrice) }}
                                    </td>
                                    <td class="h-column__accumulated">
                                        {{ numberHandler(item.Accumulated) }}
                                    </td>
                                    <td class="h-column__remaining">
                                        {{ numberHandler(item.Remaining) }}
                                    </td>
                                    <td
                                        class="h-column__tool"
                                        @dblclick="stopPropagation"
                                        @click="stopPropagation"
                                    >
                                        <div class="h-tool__block">
                                            <div class="h-tool__clone">
                                                <div
                                                    class="h-tool__clone--icon"
                                                    :AssetID="item.AssetID"
                                                    @click="showForm(item.AssetID, 'duplicate')"
                                                ></div>
                                            </div>
                                            <div class="h-tool__edit">
                                                <div
                                                    class="h-tool__edit--icon"
                                                    @click="showForm(item.AssetID)"
                                                ></div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div v-if="isLoadingAssets" class="h-table__loading">
                            <MISAIcon icon="loading"></MISAIcon>
                        </div>
                        <div v-if="isEmpty()" class="h-table__empty">
                            <MISAIcon icon="emptyBox"></MISAIcon>
                            <p class="h-empty__text">Không có bản ghi phù hợp.</p>
                        </div>
                    </div>
                    <div class="h-table__footer">
                        <div class="h-footer__left">
                            <p class="h-footer__total">
                                Tổng số: <span>{{ assetsList.length }}</span> bản ghi
                            </p>
                            <div class="h-footer__paging">
                                <MISAPaging
                                    :totalRecord="totalRecordShown"
                                    v-model:recordPerPage="recordPerPage"
                                    v-model:currentPage="currentPage"
                                ></MISAPaging>
                            </div>
                        </div>
                        <div class="h-footer__right">
                            <div class="h-footer__amounttotal">
                                {{ numberHandler(totalAmount) }}
                            </div>
                            <div class="h-footer__originaltotal">
                                {{ numberHandler(totalOriginal) }}
                            </div>
                            <div class="h-footer__accumulatedtotal">
                                {{ numberHandler(totalAccumulated) }}
                            </div>
                            <div class="h-footer__remaintotal">
                                {{ numberHandler(totalRemaining) }}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <MISAForm
            v-if="formMode != $_MISAEnum.form.formMode.hide"
            :formMode="formMode"
            :dataObject="dataObject"
            @close-form="closeForm"
            @save-form="saveForm"
        ></MISAForm>
        <MISAToastMessage
            type="warning"
            message="Tính năng đang phát triển"
            icon="warning"
            v-if="isShowTMDeveloping > 0"
        ></MISAToastMessage>
        <MISAToastMessage
            type="success"
            message="Lưu dữ liệu thành công"
            icon="success"
            v-if="isShowTMSuccess > 0"
        ></MISAToastMessage>
        <MISAContextMenu
            v-if="isShowContextMenu"
            :x="contextMenuPosition.x"
            :y="contextMenuPosition.y"
            @addAsset="showForm()"
            @editAsset="showForm(contextMenuTarget)"
            @deleteAsset="showTMDeveloping"
            @duplicateAsset="showForm(contextMenuTarget, 'duplicate')"
        ></MISAContextMenu>
    </div>
</template>

<style scoped>
@import url(./AssetsManagement.css);
</style>

<script>
// import components
import MISAButtonMain from "../components/base/MISAButton/MISAButtonMain.vue";
import MISAButtonSub from "../components/base/MISAButton/MISAButtonSub.vue";
import MISASearch from "../components/base/MISASearch/MISASearch.vue";
import MISADropdown from "../components/base/MISADropdown/MISADropdown.vue";
import MISAForm from "../components/base/MISAForm/MISAForm.vue";
import MISAIcon from "../components/base/MISAIcon/MISAIcon.vue";
import MISAToastMessage from "../components/base/MISAToastmessage/MISAToastMessage.vue";
import MISATextfield from "../components/base/MISATextfield/MISATextfield.vue";
import MISAPaging from "../components/base/MISAPaging/MISAPaging.vue";
import MISAContextMenu from "../components/base/MISAContextMenu/MISAContextMenu.vue";
import MISADatePicker from "../components/base/MISADatePicker/MISADatePicker.vue";

/**
 * Ẩn hiện form
 * @param {*} AssetID
 * @param {*} type mặc định = "" là edit, "duplicate" là nhân bản
 * Author: vtahoang - (23/06/2023)
 */
function showForm(AssetID, type = "") {
    try {
        // ẩn context menu
        this.hideContextMenu();
        // có AssetID thì là edit hoặc nhân bản, không có thì là add
        if (AssetID) {
            if (type == "duplicate") {
                this.formMode = this.$_MISAEnum.form.formMode.duplicate;
            } else this.formMode = this.$_MISAEnum.form.formMode.edit;
            this.assetsList.forEach((item) => {
                if (item.AssetID == AssetID) {
                    this.dataObject = { ...item };
                }
            });
        } else {
            this.formMode = this.$_MISAEnum.form.formMode.add;
            this.dataObject = undefined;
        }
        this.isShowForm = !this.isShowForm;
    } catch (error) {
        console.log(error);
    }
}
function closeForm() {
    this.formMode = this.$_MISAEnum.form.formMode.hide;
}

/**
 * Lưu dữ liệu thành công
 * Author: vtahoang - (13/07/2023)
 */
function saveForm() {
    try {
        this.formMode = this.$_MISAEnum.form.formMode.hide;
        this.isShowTMSuccess = 3;
        clearInterval(this.countDownSuccess);
        this.countDownSuccess = setInterval(() => {
            this.isShowTMSuccess -= 1;
            if (this.isShowTMSuccess <= 0) {
                clearInterval(this.countDownSuccess);
            }
        }, 1000);
    } catch (error) {
        console.log("saveForm ~ error:", error);
    }
}

/**
 * Update tổng
 * Author: vtahoang - (29/06/2023)
 */
function updateTotal() {
    try {
        let totalAmount = 0;
        let totalOriginal = 0;
        let totalAccumulated = 0;
        let totalRemaining = 0;
        this.assetsListShown.forEach((asset) => {
            totalAmount += asset.Amount;
            totalOriginal += asset.TheOriginalPrice;
            totalAccumulated += asset.Accumulated;
            totalRemaining += asset.Remaining;
        });
        this.totalAmount = totalAmount;
        this.totalOriginal = totalOriginal;
        this.totalAccumulated = totalAccumulated;
        this.totalRemaining = totalRemaining;
    } catch (error) {
        console.log(error);
    }
}

/**
 * Tick vào select all
 * Author: vtahoang - (29/06/2023)
 */
function selectAll() {
    try {
        this.selectAllStatus = !this.selectAllStatus;
        for (const key in this.selectedItem) {
            if (Object.hasOwnProperty.call(this.selectedItem, key)) {
                this.selectedItem[key] = this.selectAllStatus;
            }
        }
    } catch (error) {
        console.log(error);
    }
}

/**
 * Hiện toast message đang phát triển
 * Author: vtahoang - (06/07/2023)
 */
function showTMDeveloping() {
    try {
        this.isShowTMDeveloping = 3;
        clearInterval(this.countDownDeveloping);
        this.countDownDeveloping = setInterval(() => {
            this.isShowTMDeveloping -= 1;
            if (this.isShowTMDeveloping <= 0) {
                clearInterval(this.countDownDeveloping);
            }
        }, 1000);
    } catch (error) {
        console.log("showTM ~ error:", error);
    }
}

/**
 * Hiển thị danh sách tài sản theo giá trị lọc
 * Author: vtahoang - (09/07/2023)
 */
function assetsShown() {
    try {
        // lọc theo tìm kiếm, loại, bộ phận
        this.assetsListShown = this.assetsList.filter((item) => {
            return (
                (item.AssetID.toLowerCase().includes(this.searchValue.toLowerCase()) ||
                    item.Name.toLowerCase().includes(this.searchValue.toLowerCase())) &&
                item.Type.toLowerCase().includes(this.typeValue.toLowerCase()) &&
                item.Department.toLowerCase().includes(this.departmentValue.toLowerCase())
            );
        });
        //phân trang
        this.totalRecordShown = this.assetsListShown.length;
        this.assetsListShown = this.assetsListShown.slice(
            (this.currentPage - 1) * this.recordPerPage,
            (this.currentPage - 1) * this.recordPerPage + this.recordPerPage
        );
        //reset select all
        this.assetsListShown.forEach((item) => {
            this.selectedItem[item.AssetID] = false;
        });
    } catch (error) {
        console.log("assetsShown ~ error:", error);
    }
}

/**
 * Kiểm tra danh sách tài sản hiện ra có rỗng không
 * Author: vtahoang - (09/07/2023)
 */
function isEmpty() {
    try {
        if (!this.isLoadingAssets && this.assetsListShown.length <= 0) return true;
        return false;
    } catch (error) {
        console.log("isEmpty ~ error:", error);
    }
}

function created() {
    /**
     * Lấy danh sách tài sản
     * Author: vtahoang - (23/06/2023)
     */
    this.maxios
        .get("https://64952491b08e17c91791ae79.mockapi.io/HCSN")
        .then((data) => {
            this.assetsList = data.data;
            this.updateTotal();
            this.isLoadingAssets = false;
            this.assetsShown();
        })
        .catch((error) => {
            console.log(error);
        });

    /**
     * Lấy danh sách bộ phận sử dụng
     * Author: vtahoang - (13/07/2023)
     */
    this.maxios.get("https://localhost:7246/api/v1/Departments").then((data) => {
        data.data.forEach((item) => {
            this.$_MISAResources.department[item.department_code] = item.department_name;
        });
    });
}

function updated() {
    try {
        // update tổng khi có thay đổi
        this.updateTotal();
    } catch (error) {
        console.log(error);
    }
}

/**
 * click vào dòng thì select hoặc bỏ select checkbox
 * @param {*} item assetID của item
 * Author: vtahoang - (09/07/2023)
 */
function selectItem(item) {
    try {
        this.selectedItem[item] = !this.selectedItem[item];
        this.updateSelectAll();
    } catch (error) {
        console.log("selectItem ~ error:", error);
    }
}

/**
 * Cập nhật trạng thái select all
 * Author: vtahoang - (09/07/2023)
 */
function updateSelectAll() {
    try {
        Object.values(this.selectedItem).every((item) => item == true)
            ? (this.selectAllStatus = true)
            : (this.selectAllStatus = false);
    } catch (error) {
        console.log("updateSelectAll ~ error:", error);
    }
}

/**
 * Chọn dòng dữ liệu bằng phím
 * Author: vtahoang - (09/07/2023)
 */
function moveWithKey() {
    try {
        if (
            event.keyCode == this.$_MISAEnum.keyCode.keyDown &&
            this.selectedRow < this.assetsListShown.length
        ) {
            this.selectedRow += 1;
        }
        if (event.keyCode == this.$_MISAEnum.keyCode.keyUp && this.selectedRow > 1) {
            this.selectedRow -= 1;
        }
        if (event.keyCode == this.$_MISAEnum.keyCode.enter && this.selectedRow > 0) {
            this.selectedItem[this.assetsListShown[this.selectedRow - 1].AssetID] =
                !this.selectedItem[this.assetsListShown[this.selectedRow - 1].AssetID];
            this.updateSelectAll();
        }
        this.$refs.tableMain.scrollTop = (this.selectedRow - 18) * 36;
        this.preKey = event.keyCode;
    } catch (error) {
        console.log("moveWithKey ~ error:", error);
    }
}

/**
 * ẩn context menu khi click ra ngoài
 * Author: vtahoang - (12/07/2023)
 */
function hideContextMenu() {
    try {
        this.isShowContextMenu = false;
    } catch (error) {
        console.log("hideContextMenu ~ error:", error);
    }
}

/**
 * hiện context menu
 * @param {*} AssetID assetID của item
 * Author: vtahoang - (12/07/2023)
 */
function showContextMenu(AssetID) {
    try {
        event.preventDefault();
        event.stopPropagation();
        this.contextMenuTarget = AssetID;
        this.contextMenuPosition.x = event.x;
        this.contextMenuPosition.y = event.y;
        this.isShowContextMenu = true;
    } catch (error) {
        console.log("hideContextMenu ~ error:", error);
    }
}

export default {
    components: {
        MISAButtonMain,
        MISAButtonSub,
        MISASearch,
        MISADropdown,
        MISAForm,
        MISAIcon,
        MISAToastMessage,
        MISATextfield,
        MISAPaging,
        MISAContextMenu,
        MISADatePicker,
    },
    data() {
        return {
            assetsList: [], //danh sách tài sản
            assetsListShown: [], //danh sách tài sản
            isShowForm: false, //ẩn hiện form thêm/sửa tài sản
            totalAmount: 0, // tổng số lượng
            totalOriginal: 0, // tổng nguyên giá
            totalAccumulated: 0, // tổng hao mòn lũy kế
            totalRemaining: 0, // tổng giá trị còn lại
            formMode: 0, // trạng thái form
            dataObject: {}, // dữ liệu truyền vào form
            // thời gian hiện toast message đang phát triển
            isShowTMDeveloping: 0,
            // thời gian hiện toast message thành công
            isShowTMSuccess: 0,
            // đếm ngược thời gian hiện toast message đang phát triển
            countDownDeveloping: null,
            // đếm ngược thời gian hiện toast message thành công
            countDownSuccess: null,
            //số bản ghi 1 trang
            recordPerPage: 20,
            //trang hiện tại
            currentPage: 1,
            //select all checkbox
            selectAllStatus: false,
            //trạng thái loading
            isLoadingAssets: true,
            //giá trị tìm kiếm
            searchValue: "",
            //lọc theo loại tài sản
            typeValue: "",
            //lọc theo bộ phận sử dụng
            departmentValue: "",
            //tổng số bản ghi hiện ra
            totalRecordShown: 0,
            //danh sách tài sản được chọn
            selectedItem: {},
            // dòng được chọn
            selectedRow: 0,
            //ẩn hiện context menu
            isShowContextMenu: false,
            //vị trí hiện context menu
            contextMenuPosition: {
                x: 0,
                y: 0,
            },
            // context menu item
            contextMenuTarget: null,
            // nút vừa ấn trước đó
            preKey: null,
        };
    },
    methods: {
        showForm,
        updateTotal,
        closeForm,
        saveForm,
        showTMDeveloping,
        selectAll,
        isEmpty,
        assetsShown,
        selectItem,
        updateSelectAll,
        moveWithKey,
        hideContextMenu,
        showContextMenu,
    },
    watch: {
        recordPerPage() {
            this.assetsShown();
        },
        currentPage() {
            this.assetsShown();
        },
        searchValue() {
            this.assetsShown();
        },
        typeValue() {
            this.assetsShown();
        },
        departmentValue() {
            this.assetsShown();
        },
    },
    created,
    updated,
};
</script>
