<template>
    <div class="h-container">
        <TheNavbar></TheNavbar>
        <div class="h-container__right">
            <TheHeader></TheHeader>
            <div class="h-page">
                <div class="h-page__toolbar">
                    <div class="h-toolbar__left">
                        <div class="h-toolbar__search">
                            <MISASearch placeholder="Tìm kiếm tài sản"></MISASearch>
                        </div>
                        <div class="h-toolbar__assettype">
                            <MISADropdown text="Loại tài sản"></MISADropdown>
                        </div>
                        <div class="h-toolbar__department">
                            <MISADropdown text="Bộ phận sử dụng"></MISADropdown>
                        </div>
                    </div>
                    <div class="h-toolbar__right">
                        <MISAButtonSub>
                            <MISAIcon :icon="'delete'"></MISAIcon>
                        </MISAButtonSub>
                        <MISAButtonSub>
                            <MISAIcon :icon="'excel'"></MISAIcon>
                        </MISAButtonSub>
                        <MISAButtonMain :icon="'add--white'" @click="showForm()"
                            >Thêm tài sản</MISAButtonMain
                        >
                    </div>
                </div>
                <div class="h-page__table">
                    <div class="h-table__main">
                        <table>
                            <thead>
                                <th class="h-column__checkbox">
                                    <input type="checkbox" @click="selectAll" />
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
                                <tr v-for="(item, index) in assetsList" :key="item.AssetID">
                                    <td class="h-column__checkbox">
                                        <input type="checkbox" @click="ifAllChecked" />
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
                                    <td class="h-column__tool">
                                        <div class="h-tool__block">
                                            <div class="h-tool__clone">
                                                <div
                                                    class="h-tool__clone--icon"
                                                    :AssetID="item.AssetID"
                                                    @click="cloneData"
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
                    </div>
                    <div class="h-table__footer">
                        <div class="h-footer__left">
                            <p class="h-footer__total">
                                Tổng số: <span>{{ assetsList.length }}</span> bản ghi
                            </p>
                            <div class="h-footer__shownrecords">
                                <div class="h-shownrecords__text">20</div>
                                <div class="h-shownrecords__icon"></div>
                            </div>
                            <div class="h-footer__pageblock">
                                <div class="h-pageblock__backicon"></div>
                                <div class="h-pageblock__page h-pageblock__page--selected">1</div>
                                <div class="h-pageblock__page">2</div>
                                <div class="h-pageblock__page">...</div>
                                <div class="h-pageblock__page">10</div>
                                <div class="h-pageblock__nexticon"></div>
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
            v-show="formMode == $_MISAEnum.form.formMode.add"
            :formMode="formMode"
            @close-form="closeForm"
            :title="$_MISAResources.formTitle.add"
        ></MISAForm>
        <MISAForm
            v-show="formMode == $_MISAEnum.form.formMode.edit"
            :formMode="formMode"
            :dataObject="dataObject"
            @close-form="closeForm"
            :title="$_MISAResources.formTitle.edit"
        ></MISAForm>
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

/**
 * Ẩn hiện form
 * Author: vtahoang - (23/06/2023)
 */
function showForm(AssetID) {
    try {
        // có AssetID thì là edit, không có thì là add
        if (AssetID) {
            this.formMode = this.$_MISAEnum.form.formMode.edit;
            this.assetsList.forEach((item) => {
                if (item.AssetID == AssetID) {
                    this.dataObject = { ...item };
                }
            });
        } else {
            this.formMode = this.$_MISAEnum.form.formMode.add;
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
 * clone dữ liệu
 * Author: vtahoang - (29/06/2023)
 */
function cloneData(e) {
    try {
        function makeid(length) {
            let result = "";
            const characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            const charactersLength = characters.length;
            let counter = 0;
            while (counter < length) {
                result += characters.charAt(Math.floor(Math.random() * charactersLength));
                counter += 1;
            }
            return result;
        }
        this.assetsList.forEach((item, index) => {
            if (item.AssetID == e.target.getAttribute("AssetID")) {
                let newItem = { ...item };
                newItem.AssetID = makeid(10);
                this.assetsList = [
                    ...this.assetsList.slice(0, index + 1),
                    newItem,
                    ...this.assetsList.slice(index + 1),
                ];
            }
        });
    } catch (error) {
        console.log(error);
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
        this.assetsList.forEach((asset) => {
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
function selectAll(e) {
    try {
        let checkboxes = this.$el.querySelectorAll("[type=checkbox]");
        checkboxes.forEach((checkbox) => {
            checkbox.checked = e.target.checked;
        });
    } catch (error) {
        console.log(error);
    }
}

/**
 * Kiểm tra nếu tất cả tick thì tick vào select all
 * Author: vtahoang - (29/06/2023)
 */
function ifAllChecked() {
    try {
        let checkboxes = this.$el.querySelectorAll("td [type=checkbox]");
        let checked = true;
        checkboxes.forEach((checkbox) => {
            if (!checkbox.checked) {
                checked = false;
            }
        });
        this.$el.querySelector(".h-column__checkbox input").checked = checked;
    } catch (error) {
        console.log(error);
    }
}

function created() {
    /**
     * Lấy danh sách tài sản
     * Author: vtahoang - (23/06/2023)
     */
    // fetch("https://64952491b08e17c91791ae79.mockapi.io/HCSN")
    //     .then((response) => response.json())
    //     .then((data) => {
    //         this.assetsList = data;
    //         this.updateTotal();
    //     })
    //     .catch((error) => {
    //         console.log(error);
    //     });
    this.maxios
        .get("https://64952491b08e17c91791ae79.mockapi.io/HCSN")
        .then((data) => {
            this.assetsList = data.data;
            this.updateTotal();
        })
        .catch((error) => {
            console.log(error);
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

export default {
    components: {
        MISAButtonMain,
        MISAButtonSub,
        MISASearch,
        MISADropdown,
        MISAForm,
        MISAIcon,
    },

    data: () => {
        return {
            assetsList: [], //danh sách tài sản
            isShowForm: false, //ẩn hiện form thêm/sửa tài sản
            totalAmount: 0, // tổng số lượng
            totalOriginal: 0, // tổng nguyên giá
            totalAccumulated: 0, // tổng hao mòn lũy kế
            totalRemaining: 0, // tổng giá trị còn lại
            formMode: 0, // trạng thái form
            dataObject: {},
        };
    },
    methods: {
        showForm,
        cloneData,
        updateTotal,
        selectAll,
        ifAllChecked,
        closeForm,
    },
    created,
    updated,
};
</script>
