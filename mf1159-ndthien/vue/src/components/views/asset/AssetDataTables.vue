<template>
    <div class="content__table">
        <div class="table">
            <table>
                <thead>
                    <tr class="table__row--fixed">
                        <th
                            class="table__cell--checkbox table__cell--fixed first-column--fixed"
                        >
                            <MISACheckbox
                                v-model="isAllRowSelect"
                                @click="handleAllRowSelect()"
                                :isDisabled="fixedAssets.length == 0"
                            />
                        </th>
                        <th
                            class="table__cell--50px text-center"
                            :title="
                                dataTableResource.HeaderColumn.SortOrder.Tooltip
                            "
                        >
                            {{ dataTableResource.HeaderColumn.SortOrder.Text }}
                        </th>
                        <th class="table__cell--90px text-left">
                            {{ dataTableResource.HeaderColumn.AssetCode.Text }}
                        </th>
                        <th class="table__cell--200px text-left">
                            {{ dataTableResource.HeaderColumn.AssetName.Text }}
                        </th>
                        <th class="table__cell--150px text-left">
                            {{
                                dataTableResource.HeaderColumn.AssetCategoryName
                                    .Text
                            }}
                        </th>
                        <th class="table__cell--160px text-left">
                            {{ dataTableResource.HeaderColumn.Department.Text }}
                        </th>
                        <th class="table__cell--70px text-right">
                            {{ dataTableResource.HeaderColumn.Quantity.Text }}
                        </th>
                        <th class="table__cell--130px text-right">
                            {{ dataTableResource.HeaderColumn.Cost.Text }}
                        </th>
                        <th class="table__cell--130px text-right">
                            HM/KH lũy kế
                        </th>
                        <th class="table__cell--130px text-right">
                            Giá trị còn lại
                        </th>
                        <th
                            class="table__cell--fixed last-column--fixed text-center"
                        >
                            {{ dataTableResource.HeaderColumn.Function.Text }}
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <MISALoadingTable v-if="isLoading" />
                    <MISAEmptyTable
                        v-if="fixedAssets.length == 0 && !isLoading"
                    />
                    <tr
                        v-for="(asset, index) in fixedAssets"
                        :key="asset.fixed_asset_id"
                        @mouseover="showBtnFunction(index)"
                        @mouseout="hideBtnFunction()"
                        @dblclick="
                            $emit(
                                'openAssetDetail',
                                $_MISAEnum.FormMode.Edit,
                                asset
                            )
                        "
                    >
                        <td
                            class="table__cell--checkbox table__cell--fixed first-column--fixed"
                            @dblclick.prevent
                        >
                            <MISACheckbox
                                v-model="rowSelected"
                                :value="index"
                            />
                        </td>
                        <td class="table__cell--50px text-center">
                            {{ index + 1 }}
                        </td>
                        <td class="table__cell--90px text-left">
                            {{ asset.fixed_asset_code }}
                        </td>
                        <td class="table__cell--200px text-left">
                            {{ asset.fixed_asset_name }}
                        </td>
                        <td class="table__cell--150px text-left">
                            {{ asset.fixed_asset_category_name }}
                        </td>
                        <td class="table__cell--160px text-left">
                            {{ asset.department_name }}
                        </td>
                        <td class="table__cell--70px text-right">
                            {{
                                $_MISAFunctions.convertNumberToCurrency(
                                    asset.quantity
                                )
                            }}
                        </td>
                        <td class="table__cell--130px text-right">
                            {{
                                $_MISAFunctions.convertNumberToCurrency(
                                    asset.cost
                                )
                            }}
                        </td>
                        <td class="table__cell--130px text-right">
                            {{
                                $_MISAFunctions.convertNumberToCurrency(
                                    asset.depreciation_value
                                )
                            }}
                        </td>
                        <td class="table__cell--130px text-right">
                            {{
                                $_MISAFunctions.convertNumberToCurrency(
                                    asset.residualValue
                                )
                            }}
                        </td>

                        <td
                            class="table__cell--fixed last-column--fixed text-center"
                        >
                            <div v-show="isShowBtnFunction[index]">
                                <MISAButton
                                    type="btn-icon"
                                    icon="edit"
                                    :size="16"
                                    @click="
                                        $emit(
                                            'openAssetDetail',
                                            $_MISAEnum.FormMode.Edit,
                                            asset
                                        )
                                    "
                                />
                                <MISAButton
                                    type="btn-icon"
                                    icon="copy"
                                    :size="16"
                                    class="ml-12"
                                    @click="
                                        $emit(
                                            'openAssetDetail',
                                            $_MISAEnum.FormMode.Duplicate,
                                            asset
                                        )
                                    "
                                />
                            </div>
                        </td>
                    </tr>
                </tbody>
                <tfoot v-show="fixedAssets.length != 0">
                    <tr>
                        <td colspan="6">
                            <MISAPagination
                                :totalRecords="totalRecords"
                                @handlePageSizeChanged="handlePageSizeChanged"
                                @handlePageNumberChanged="
                                    handlePageNumberChanged
                                "
                            />
                        </td>
                        <td class="text-right text-bold">
                            {{
                                $_MISAFunctions.convertNumberToCurrency(
                                    totalQuantityAsset
                                )
                            }}
                        </td>
                        <td class="text-right text-bold">
                            {{
                                $_MISAFunctions.convertNumberToCurrency(
                                    totalCostAsset
                                )
                            }}
                        </td>
                        <td class="text-right text-bold">0</td>
                        <td class="text-right text-bold">0</td>
                        <td></td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</template>
<script>
export default {
    name: "AssetDataTables",
    props: {
        fixedAssets: {
            // Danh sách tài sản binding lên datatable
            type: Array,
            required: false,
            default: () => [],
        },
        isLoading: {
            // Trạng thái loading của table
            type: Boolean,
            required: false,
            default: false,
        },
        pageSize: {
            // Số bản ghi trên một trang
            type: Number,
            required: true,
            default: 10,
        },
        totalRecords: {
            // Tổng số bản ghi
            type: Number,
            required: true,
            default: 0,
        },
    },
    data() {
        return {
            dataTableResource: this.$_MISAResource.VN.Table, // Get resource
            isShowBtnFunction: [], // Giá trị lưu index row hover để hiện button function
            isAllRowSelect: false, // Chọn toàn bộ hàng trong bảng
            rowSelected: [], // Các hàng đang được chọn trong bảng,
        };
    },
    created() {},
    computed: {
        /**
         * Tính toán tổng số lượng của danh sách tài sản hiển thị trên bảng
         * Author: NDThien 13/07/2023
         */
        totalQuantityAsset() {
            return this.fixedAssets.reduce(
                (totalQuantity, item) => totalQuantity + item.quantity,
                0
            );
        },
        /**
         * Tính toán tổng số nguyên giá của danh sách tài sản hiển thị trên bảng
         * Author: NDThien 13/07/2023
         */
        totalCostAsset() {
            return this.fixedAssets.reduce(
                (totalQuantity, item) => totalQuantity + item.cost,
                0
            );
        },
    },
    methods: {
        /**
         * Set hiện button function cho row[index]
         * @param {*} index: Vị trí index row hover
         * Auhtor: NDThien 1/7/2023
         */
        showBtnFunction(index) {
            this.isShowBtnFunction[index] = true;
        },
        /**
         * Clear toàn bộ phần tử mảng để ẩn button function khi không còn hover
         * Author: NDThien 1/7/2023
         */
        hideBtnFunction() {
            this.isShowBtnFunction = [];
        },
        /**
         * Chọn toàn bộ checkbox các hàng
         * Author: NDThien 3/7/2023
         */
        checkAllRow() {
            this.rowSelected = []; //Vì push nên cần reset mảng về rỗng để xóa hết phần tử đã chọn cũ
            for (let i = 0; i < this.fixedAssets.length; ++i) {
                this.rowSelected.push(i);
            }
        },
        /**
         * Hủy chọn toàn bộ checkbox các hàng
         * Author: NDThien 3/7/2023
         */
        unCheckAllRow() {
            this.rowSelected = [];
        },
        /**
         * Chọn tất cả các hàng tùy vào trạng thái của checkbox header
         * Author: NDThien 3/7/2023
         */
        handleAllRowSelect() {
            if (!this.isAllRowSelect) {
                // Giá trị cũ là false thì thực hiện checkAllRow
                this.checkAllRow();
            } else {
                this.unCheckAllRow();
            }
        },
        /**
         * Emit lên parent để cập nhật danh sách data theo sự thay đổi của pageSize
         * @param {*} pageSize Số bản ghi trên một trang
         * Author: NDThien 27/07/2023
         */
        handlePageSizeChanged(pageSize) {
            this.$emit("handlePageSizeChanged", pageSize);
        },
        /**
         * Emit pageSize lên parent để cập nhật lại danh sách theo pageNumber
         * @param {*} pageSize Vị trí trang hiện tại
         * Author: NDThien 27/07/2023
         */
        handlePageNumberChanged(pageNumber) {
            this.$emit("handlePageNumberChanged", pageNumber);
        },
    },
    watch: {
        /**
         * Theo dõi sự thay đổi của các hàng được chọn để thay đổi giá trị của checkbox header (allRowSelect)
         * @param {*} newValue Giá trị thay đổi
         */
        rowSelected: {
            handler(newValue) {
                if (newValue.length == this.fixedAssets.length) {
                    this.isAllRowSelect = true;
                } else {
                    this.isAllRowSelect = false;
                }
                this.$emit("assetsSelected", newValue);
            },
            deep: true,
        },
    },
};
</script>
<style scoped>
@import url(../../../css/base/table.css);
</style>
