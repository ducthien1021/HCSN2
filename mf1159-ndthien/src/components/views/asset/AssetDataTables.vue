<template lang="">
    <div class="content__table">
        <div class="table">
            <table>
                <thead>
                    <tr class="table__row--fixed">
                        <th
                            class="table__cell--checkbox table__cell--fixed first-column--fixed"
                        >
                            <MISACheckbox />
                        </th>
                        <th class="table__cell--50px text-center">STT</th>
                        <th class="table__cell--90px text-left">Mã tài sản</th>
                        <th class="table__cell--200px text-left">
                            Tên tài sản
                        </th>
                        <th class="table__cell--150px text-left">
                            Loại tài sản
                        </th>
                        <th class="table__cell--160px text-left">
                            Bộ phận sử dụng
                        </th>
                        <th class="table__cell--70px text-right">Số lượng</th>
                        <th class="table__cell--130px text-right">
                            Nguyên giá
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
                            Chức năng
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr
                        v-for="(asset, index) in assets"
                        :key="asset.fixed_asset_code"
                        @mouseover="showBtnFunction(index)"
                        @mouseout="hideBtnFunction()"
                    >
                        <td
                            class="table__cell--checkbox table__cell--fixed first-column--fixed"
                        >
                            <MISACheckbox />
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
                            {{ asset.quantity }}
                        </td>
                        <td class="table__cell--130px text-right">
                            {{ asset.cost }}
                        </td>
                        <td class="table__cell--130px text-right">
                            {{ asset.depreciation }}
                        </td>
                        <td class="table__cell--130px text-right">
                            {{ asset.residualValue }}
                        </td>

                        <td
                            class="table__cell--fixed last-column--fixed text-center"
                        >
                            <div v-show="isShowBtnFunction[index]">
                                <MISAButton
                                    type="btn-icon"
                                    icon="edit"
                                    :size="16"
                                />
                                <MISAButton
                                    type="btn-icon"
                                    icon="copy"
                                    :size="16"
                                    class="ml-12"
                                />
                            </div>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="6">
                            <MISAPagination :totalRecord="200" />
                        </td>
                        <td class="text-right text-bold">13</td>
                        <td class="text-right text-bold">24900000</td>
                        <td class="text-right text-bold">19716000</td>
                        <td class="text-right text-bold">19716000</td>
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
    data() {
        return {
            assets: [
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
                {
                    fixed_asset_code: "TS001",
                    fixed_asset_name: "Máy tính xách tay Fujitsu",
                    fixed_asset_category_name: "Máy vi tính sách tay",
                    department_name: "Phòng hành chính kế toán",
                    quantity: 1,
                    cost: "20.000.000",
                    depreciation: "894.000",
                    residualValue: "19.106.000	",
                },
            ],
            isShowBtnFunction: [], // Giá trị lưu index row hover để hiện button function
        };
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
    },
};
</script>
<style scoped>
@import url(../../../css/base/table.css);
</style>
