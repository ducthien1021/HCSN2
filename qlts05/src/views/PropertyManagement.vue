<template>
    <div class="property-page">
        <div class="page-header">
            <div class="header__left">
                <MISASearchInput />
                <MISASelectInput placeholder="Loại tài sản" />
                <MISASelectInput placeholder="Bộ phận sử dụng" />
            </div>
            <div class="header__right">
                <MISANormalButton @click="showForm">
                    <p>+ Thêm tài sản</p>
                </MISANormalButton>
                <MISAIconButton @click="selectAllRow">
                    <MISAIcon class="icon" :pX="this.$_icons.excel.pX" :pY="this.$_icons.excel.pY"
                        :width="this.$_icons.excel.width" :height="this.$_icons.excel.height" />
                </MISAIconButton>
                <MISAIconButton>
                    <MISAIcon class="icon" :pX="this.$_icons.delete.pX" :pY="this.$_icons.delete.pY"
                        :width="this.$_icons.delete.width" :height="this.$_icons.delete.height" />
                </MISAIconButton>
            </div>
        </div>
        <div class="table-status" v-if="numSelectedRows > 0">
            <div class="selected-row">Đã chọn <strong>{{ numSelectedRows }}</strong></div>
            <button class="deselect" @click="deselectAllRows">Bỏ chọn</button>
        </div>
        <div class="table-wrapper">
            <MISATable v-on:update:num-selected-rows="onNumSelectedRowsUpdated" :do-select-all="selectedAllRows"
                :do-deselect-all="deselectAllRows" ref="misa-table" />
        </div>
        <MISAAddPropertyForm :isOpen="isFormOpen" @close="closeForm" />
    </div>
</template>
<script>
import MISASearchInput from '@/components/base/input/MISASearchInput.vue'
import MISANormalButton from '@/components/base/button/MISANormalButton.vue'
import MISAIconButton from '@/components/base/button/MISAIconButton.vue';
import MISAIcon from '@/components/base/icon/MISAIcon.vue';
import MISASelectInput from '@/components/base/input/MISASelectInput.vue';
import MISATable from '@/components/base/table/MISATable.vue';
import MISAAddPropertyForm from '@/components/form/MISAAddPropertyForm.vue';

export default {
    name: 'PropertyManagement',
    components: {
        MISASearchInput,
        MISANormalButton,
        MISAIconButton,
        MISAIcon,
        MISASelectInput,
        MISATable,
        MISAAddPropertyForm,

    },
    data() {
        return {
            numSelectedRows: 0, // Số lượng các dòng được chọn
            isFormOpen: false, // Trạng thái mở form thêm mới tài sản
        };
    },
    methods: {
        /**
         * 
         * @param {*} numSelectedRows 
         * @description: Hàm được gọi khi số lượng các dòng được chọn thay đổi
         * @returns
         * Author: PQNAM (29/06/2023)
         */
        onNumSelectedRowsUpdated(numSelectedRows) {
            this.numSelectedRows = numSelectedRows;
        },

        /**
         * Chọn tất cả các hàng
         * Author: PQNAM (29/06/2023)
         */
        selectAllRow() {
            this.$refs['misa-table'].selectAllData();
        },

        /**
         * Bỏ chọn tất cả các hàng
         * Author: PQNAM (29/06/2023)
         */
        deselectAllRows() {
            this.$refs['misa-table'].deselectedAll();
        },

        /**
         * Mở form thêm mới tài sản
         * Author: PQNAM (29/06/2023)
         */
        showForm() {
            this.isFormOpen = true;
        },

        /**
         * Đóng form thêm mới tài sản
         * Author: PQNAM (29/06/2023)
         */
        closeForm() {
            this.isFormOpen = false;
        }
    },
}
</script>

<style scoped>
.property-page {
    width: 100%;
    height: 100%;
    padding: 20px;
    box-sizing: border-box;
    display: flex;
    flex-direction: column;
}

.page-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 36px;
    box-sizing: border-box;
    margin-bottom: 13px;
}

.header__left {
    display: flex;
    align-items: center;
    column-gap: 11px;

}

.header__right {
    display: flex;
    align-items: center;
    column-gap: 11px;
}

.table-wrapper {
    background-color: #fff;
    border: 1px solid #afafaf;
    border-radius: 4px;
    box-sizing: border-box;
}

.table-status {
    height: 36px;
    box-sizing: border-box;
    width: 100%;
    margin-bottom: 13px;
    display: flex;
    align-items: center;
    padding-left: 20px;
    padding-right: 20px;

}

.selected-row {
    font-size: 14px;
    margin-right: 20px;

}

.deselect {
    border: none;
    outline: none;
    background-color: transparent;
    color: rgb(30, 112, 255);
    font-size: 14px;
    height: 100%;
}

.deselect:hover {
    cursor: pointer;
    text-decoration: underline;
}
</style>