<template>
    <div class="table-data">

        <div class="table-body" :class="{ 'resize': rowCount > 0 }">
            <table>
                <thead>
                    <tr>
                        <th class="checkbox" :class="{ 'multiple-rows-selected': rowCount > 0 && rowCount < pageSize }">

                            <input type="checkbox" v-model="isAllSelected" @click="selectAll" />
                            <span class="checkbox-icon"></span>

                        </th>
                        <th class="stt">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.Order }}</th>
                        <th class="prop-code">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.AssetCode }}</th>
                        <th class="prop-name">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.AssetName }}</th>
                        <th class="prop-type">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.AssetType }}</th>
                        <th class="prop-use">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.Department }}</th>
                        <th class="quantity">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.Quantity }}</th>
                        <th class="pri-cost">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.FixedAssetCost }}</th>
                        <th class="accum">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.AccumDep }}</th>
                        <th class="after-cost">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.SalValue }}</th>
                        <th class="func">{{ this.$_MISAResource[this.$_LANGCODE].TableInfo.Function }}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(property, index) in paginatedProperties" :key="index">
                        <td class="checkbox"><input type="checkbox" :value="property.id" v-model="selectedProperties"
                                @click="selectMulti(property.id)" />
                            <span class="checkbox-icon"></span>
                        </td>
                        <td class="stt">{{ index + pageSize * (currentPage - 1) + 1 }}</td>
                        <td class="prop-code">{{ property.assetCode }}</td>
                        <td class="prop-name">{{ property.assetName }}</td>
                        <td class="prop-type">{{ property.assetType }}</td>
                        <td class="prop-use">{{ property.department }}</td>
                        <td class="quantity">{{ this.formattedNumber(property.quantity) }}</td>
                        <td class="pri-cost">{{ this.formattedNumber(property.fixedCost) }}</td>
                        <td class="accum">{{ this.formattedNumber(property.accumDep) }}</td>
                        <td class="after-cost">{{ this.formattedNumber(property.salValue) }}</td>
                        <td class="func"></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="table-footer">
            <div class="pagination">
                <span class="total">Tổng số: <strong>{{ properties.length }}</strong> bản ghi</span>

                <div class="select">
                    <select class="page-size" v-model="pageSize">
                        <option v-for="size in pageSizes" :key="size" :value="size">{{ size }}</option>
                    </select>
                    <MISAIcon class="select-icon" :pX="this.$_icons.arrowDown.pX" :pY="this.$_icons.arrowDown.pY"
                        :width="this.$_icons.arrowDown.width" :height="5" :scale="this.$_icons.arrowDown.scale" />
                </div>
                <span class="paging" v-if="totalPages > 1">
                    <button class="next" :disabled="currentPage === 1" @click="prevPage">&#60;</button>
                    <button :class="{ active: currentPage === 1 }" @click="goToPage(1)">1</button>
                    <span v-if="showDotsBefore">...</span>
                    <button v-for="page in visiblePages" :key="page" :class="{ active: currentPage === page }"
                        @click="goToPage(page)">{{ page }}</button>
                    <span v-if="showDotsAfter">...</span>
                    <button :class="{ active: currentPage === totalPages }" @click="goToPage(totalPages)">{{ totalPages
                    }}</button>
                </span>

                <button class="next" :disabled="currentPage === totalPages" @click="nextPage">&#62;</button>
            </div>
            <div class="data-summary">
                <div class="quantity">{{ this.formattedNumber(totalQuantity) }}</div>
                <div class="pri-cost">{{ this.formattedNumber(totalCost) }}</div>
                <div class="accum">{{ this.formattedNumber(totalAccum) }}</div>
                <div class="after-cost">{{ this.formattedNumber(totalSalValue) }}</div>
                <div class="func"></div>
            </div>
        </div>

    </div>
</template>
  
<script>
import MISAIcon from "../icon/MISAIcon.vue";
import { properties } from "../../../mocks/properties.js";
export default {
    name: "MISATable",
    components: {
        MISAIcon
    },
    props: {
        selectedAllRows: Function, // truyền hàm xử lý khi chọn tất cả các hàng
        deselectAllRows: Function, // truyền hàm xử lý khi bỏ chọn tất cả các hàng
    },
    data() {
        return {
            currentPage: 1, // trang hiện tại
            pageSize: 20, // số hàng trên một trang
            pageSizes: [5, 10, 20], // số hàng trên một trang
            properties: properties, // danh sách tài sản
            selectedProperties: [], // các hàng đã chọn trên trang hiện tại
            selectedOnAllPages: [], // các hàng đã chọn trên tất cả các trang
            isAllSelected: false, // trạng thái của ô checkbox header
            currentSelectedProperties: [], // các hàng đã chọn trên trang hiện tại
            change: false, // trạng thái thay đổi của ô checkbox header
            rowCount: 0, // số hàng đã chọn
        };
    },
    computed: {
        /**
         * Tính tổng số trang
         * @returns {number}
         * Author: PQNAM (26/06/2023)
         */
        totalPages() {
            return Math.ceil(this.properties.length / this.pageSize);
        },

        /**
         * Tính chỉ số cho phân trang
         * @returns {number}
         * Author: PQNAM (26/06/2023)
         */
        visiblePages() {
            const maxVisiblePages = 3;
            let startPage = this.currentPage - Math.floor(maxVisiblePages / 2);
            if (startPage < 1) {
                startPage = 1;
            }
            let endPage = startPage + maxVisiblePages - 1;
            if (endPage > this.totalPages) {
                endPage = this.totalPages;
                startPage = endPage - maxVisiblePages + 1;
                if (startPage < 1) {
                    startPage = 1;
                }
            }

            const pages = [];
            for (let i = startPage; i <= endPage; i++) {
                pages.push(i);
            }

            // Ẩn phần tử startPage nếu nó bằng 1
            if (startPage === 1 && this.currentPage === 1) {
                pages.shift();
                pages.pop();
            }
            if (startPage === 1 && this.currentPage === 2) {
                pages.shift();
            }
            // Ẩn phần tử endPage nếu nó bằng this.totalPages
            if (endPage === this.totalPages && this.currentPage === this.totalPages) {
                pages.pop();
                pages.shift();
            }
            if (endPage === this.totalPages && this.currentPage === this.totalPages - 1) {
                pages.pop();
            }
            return pages;
        },

        /**
         * Kiểm tra xem có hiển thị dấu ... ở đầu phân trang hay không
         * @returns {boolean}
         * Author: PQNAM (26/06/2023)
         */
        showDotsBefore() {
            return this.visiblePages[0] > 2;
        },

        /**
         * Kiểm tra xem có hiển thị dấu ... ở cuối phân trang hay không
         * @returns {boolean}
         * Author: PQNAM (26/06/2023)
         */
        showDotsAfter() {
            return this.visiblePages[this.visiblePages.length - 1] < this.totalPages - 1;
        },

        /**
         * Lấy danh sách các hàng được phân trang
         * @returns {*[]}
         * Author: PQNAM (26/06/2023)
         */
        paginatedProperties() {
            const startIndex = (this.currentPage - 1) * this.pageSize;
            const endIndex = startIndex + this.pageSize;
            return this.properties.slice(startIndex, endIndex);
        },

        totalQuantity() {
            return this.properties.reduce((sum, property) => sum + property.quantity, 0);
        },

        totalCost() {
            return this.properties.reduce((sum, property) => sum + property.fixedCost, 0);
        },
        totalAccum() {
            return this.properties.reduce((sum, property) => sum + property.accumDep, 0);
        },
        totalSalValue() {
            return this.properties.reduce((sum, property) => sum + property.salValue, 0);
        },
    },
    methods: {
        /**
         * Chuyển đến trang trước
         * Author: PQNAM (26/06/2023)
         */
        prevPage() {
            this.currentPage -= 1;
        },

        /**
         * Chuyển đến trang sau
         * Author: PQNAM (26/06/2023)
         */
        nextPage() {
            this.currentPage += 1;
        },

        /**
         * Chuyển đến trang được chọn
         * @param page
         * Author: PQNAM (26/06/2023)
         */
        goToPage(page) {
            this.currentPage = page;
        },

        /**
         * Chọn tất cả các hàng trên trang hiện tại
         * Author: PQNAM (26/06/2023)
         */
        selectAll() {
            if (!this.isAllSelected) {
                const selectedIds = this.paginatedProperties.map(property => property.id);

                // Loại bỏ các giá trị trùng trong selectedIds trước khi thêm vào selectedProperties
                const uniqueSelectedIds = selectedIds.filter(id => !this.selectedProperties.includes(id));
                this.selectedProperties = [...this.selectedProperties, ...uniqueSelectedIds];
                this.change = !this.change;
            } else {
                const deselectedIds = this.paginatedProperties.map(property => property.id);
                this.selectedProperties = this.selectedProperties.filter(id => !deselectedIds.includes(id));
                this.change = !this.change;
            }
        },

        /**
         * Chọn hàng hiện tại
         * Author: PQNAM (26/06/2023)
         */
        selectMulti(id) {
            if (this.selectedProperties.includes(id)) {
                this.selectedProperties = this.selectedProperties.filter(property => property !== id);
                this.change = !this.change;
            } else {
                this.selectedProperties.push(id);
                this.change = !this.change;
            }
        },

        /**
         * Định dạng số (tiền)
         * @param {*} value 
         * Author: PQNAM (26/06/2023)
         */
        formattedNumber(value) {
            return value.toLocaleString('vi', {
                useGrouping: true,
                maximumFractionDigits: 0,
                groupingSeparator: '.',
            });
        },

        /**
         * Định dạng ngày tháng
         * @param {*} value
         * Author: PQNAM (26/06/2023)
         */
        updateNumSelectedRows: function () {
            this.$emit('update:num-selected-rows', this.getNumSelectedRows());
        },

        /**
         * Lấy số hàng được chọn
         * Author: PQNAM (26/06/2023)
         */
        getNumSelectedRows: function () {
            return this.selectedProperties.length;
        },

        /**
         * Bỏ chọn hàng được chọn
         * Author: PQNAM (26/06/2023)
         */
        deselectedAll() {
            this.selectedProperties = [];
            this.change = !this.change;
        },

        /**
         * Chọn tất cả các hàng
         * Author: PQNAM (26/06/2023)
         */
        selectAllData() {

            const selectedIds = this.properties.map(property => property.id);
            this.selectedProperties = [];
            // Loại bỏ các giá trị trùng trong selectedIds trước khi thêm vào selectedProperties

            this.selectedProperties = [...this.selectedProperties, ...selectedIds];
            this.change = !this.change;
            console.log(this.selectedProperties);
        }

    },

    watch: {
        /**
         * Xử lý khi pageSize thay đổi
         * @param newPageSize
         * @param oldPageSize
         * Author: PQNAM (26/06/2023)
         */
        pageSize: function (newPageSize, oldPageSize) {
            if (newPageSize !== oldPageSize) {
                this.currentPage = 1; // Set currentPage back to 1 when pageSize changes
                this.change = !this.change;
            }
        },

        /**
         * 
         * @param {*} newValue 
         * @param {*} oldValue 
         * Author: PQNAM (26/06/2023)
         */
        change: function (newValue, oldValue) {
            if (newValue !== oldValue) {

                this.currentSelectedProperties = this.paginatedProperties.filter(
                    (property) => this.selectedProperties.includes(property.id)
                );
                this.rowCount = this.currentSelectedProperties.length;
                this.isAllSelected = this.currentSelectedProperties.length === this.paginatedProperties.length;
            }
            this.updateNumSelectedRows();
            console.log(this.rowCount);
            console.log(this.selectedProperties);
        },

        /**
         * Xử lý khi currentPage thay đổi
         * Author: PQNAM (26/06/2023)
         */
        currentPage: function () {
            this.currentSelectedProperties = [];
            this.currentSelectedProperties = this.paginatedProperties.filter(
                (property) => this.selectedProperties.includes(property.id)
            );
            this.rowCount = this.currentSelectedProperties.length;
            this.isAllSelected = this.currentSelectedProperties.length === this.paginatedProperties.length;
        },

        /**
         * Xử lý khi selectedProperties thay đổi
         * Author: PQNAM (26/06/2023)
         */
        rowCount: function () {
            if (this.rowCount === 0) {
                console.log("Không có hàng nào được chọn");
            }
        }
    },
};
</script>

<style scoped>
.table-data {
    width: 100%;
    border-collapse: collapse;
    height: 100%;
    display: flex;
    flex-direction: column;
}

/*.table-data.resize {
    max-height: 520px;
}*/
.table-body {
    width: 100%;
    overflow: auto;
    position: relative;
    max-height: 520px;
}

/*.table-body.resize {
    max-height: 480px;
}*/
.table-body::-webkit-scrollbar {
    display: none;
}

table {
    width: 100%;
    font-size: 13px;
    border-collapse: collapse;
    border: unset;
}

table thead {
    position: sticky;
    background: #f5f5f5;
    top: 0;
    z-index: 1;
}

tbody tr {
    height: 40px;
    box-sizing: border-box;
}

tbody tr:hover {

    background-color: rgba(26, 164, 200, .2);
    cursor: pointer;
}

thead tr {
    height: 40px;
    box-sizing: border-box;
}

thead th {
    text-align: left;
    font-size: 13px;
    height: 40px;
    box-sizing: border-box;
}

tbody td {

    text-align: left;
    border-bottom: 1px solid #e0e1e4;
    text-overflow: ellipsis;
    font-size: 13px;
    height: 40px;
    box-sizing: border-box;
}

thead th {
    font-weight: 700;
}

th,
td {
    max-width: 0;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}

.stt {
    text-align: center;
}


td.checkbox {
    text-align: center;
}




.checkbox {
    width: var(--checkbox-column-widths);
}

.stt {
    width: var(--id-column-widths);
}

.prop-code {
    width: var(--code-column-widths);
}

.prop-name {
    width: var(--name-column-widths);
}

.prop-type {
    width: var(--type-column-widths);
}

.quantity {
    width: var(--quantity-column-widths);
    text-align: right;

}

.pri-cost {
    width: var(--cost-column-widths);
    text-align: right;
}

.accum {
    width: var(--accum-column-widths);
    text-align: right;
}

.after-cost {
    width: var(--remain-column-widths);
    text-align: right;
}

.func {
    width: var(--func-column-widths);
    text-align: center;
}



.checkbox {
    text-align: center;
    position: relative;
}

.checkbox input[type='checkbox'] {
    opacity: 0;
    cursor: pointer;
}

.checkbox .checkbox-icon {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 14px;
    height: 14px;
    background: url('@/assets/icon/qlts-icon.svg') no-repeat -113px -377px;
    background-color: #fff;
    pointer-events: none;
}

.checkbox>input:checked+.checkbox-icon {
    background: url('@/assets/icon/qlts-icon.svg') no-repeat -157px -377px;
    pointer-events: none;
}

.checkbox.multiple-rows-selected>input+.checkbox-icon {
    background: url('@/assets/icon/qlts-icon.svg') no-repeat -421px -377px;
}

.checkbox.multiple-rows-selected>input:checked+.checkbox-icon {
    background: url('@/assets/icon/qlts-icon.svg') no-repeat -157px -377px;
}

tbody :has(td input[type="checkbox"]:checked) {
    background-color: #e6f7ff;
}

.table-footer {
    display: flex;
    justify-content: space-between;
    align-items: center;
    box-sizing: border-box;
    padding-left: 20px;
    height: 40px;
    border-top: 1px solid #e0e1e4;

}

.pagination {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    height: 100%;
}


span.total {
    font-size: 11px;
}

.select {
    width: 60px;
    height: 25px;
    border: 1px solid #afafaf;
    box-sizing: border-box;
    border-radius: 2.625px;
    position: relative;
    margin: 0 20px 0 36px;
}

select.page-size {
    width: 100%;
    height: 100%;
    border: unset;
    overflow: unset;
    font-size: 11px;
    text-align: center;
    -webkit-appearance: none;
    appearance: none;

}

.select-icon {
    top: -1px;
    right: 0;
    position: absolute;
    pointer-events: none;
}

select.page-size:focus {
    outline: none;
}

button {
    background-color: #fff;
    color: #000;
    border: none;
    outline: none;
    margin-right: 7px;
    cursor: pointer;
    font-size: 11px;
    width: 20px;
    height: 20px;
    border-radius: 3px;
}

button.active {
    background-color: #f5f5f5;
}

button:disabled {
    cursor: default;
    opacity: 0.5;
}

button:focus {
    outline: none;
}

.next {
    font-weight: 700;
}

.data-summary {
    display: flex;
    align-items: center;
    box-sizing: border-box;
    height: 100%;
    width: var(--summary-widths);
    font-size: 13px;
    text-align: right;
}

.data-summary .quantity,
.data-summary .pri-cost,
.data-summary .accum,
.data-summary .after-cost {
    text-align: right;
    font-weight: 700;
}

.data-summary .quantity {
    width: var(--summary-quantity-widths);

}

.data-summary .pri-cost {
    width: var(--summary-cost-widths);
}

.data-summary .accum {
    width: var(--summary-accum-widths);
}

.data-summary .after-cost {
    width: var(--summary-cost-widths);
}

.data-summary .func {
    width: var(--summary-func-widths);

}
</style>