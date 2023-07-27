<template>
    <div class="content">
        <div class="content__top">
            <div class="content__left">
                <MISAInput
                    class="flex-1"
                    placeholder="Tìm kiếm tài sản"
                    prefixIcon="search"
                    v-model="filterSearch.value"
                    @keyup.enter="handleSearchValue"
                />
                <MISACombobox
                    class="flex-1"
                    :iconFilter="true"
                    placeholder="Loại tài sản"
                    :dataSource="departments"
                    :dataFields="dataFields"
                />
                <MISACombobox
                    class="flex-1"
                    :iconFilter="true"
                    placeholder="Bộ phận sử dụng"
                    :dataSource="departments"
                    :dataFields="dataFields"
                />
            </div>
            <div class="content__right">
                <MISAButton
                    type="main"
                    icon="add"
                    text="Thêm tài sản"
                    @click="openAssetDetail($_MISAEnum.FormMode.Add)"
                />
                <MISAButton type="btn-icon" icon="excel" />
                <MISAButton
                    type="btn-icon"
                    icon="delete"
                    :disabled="assetsSelected.length == 0"
                    @click="onClickBtnDelete()"
                />
            </div>
        </div>

        <AssetDataTables
            @openAssetDetail="openAssetDetail"
            :fixedAssets="fixedAssets"
            :isLoading="isLoadingDataTable"
            @assetsSelected="getAssetsSelected"
            :totalRecords="pagingFilter.total_records"
            @handlePageSizeChanged="handlePageSizeChanged"
            @handlePageNumberChanged="handlePageNumberChanged"
        />

        <AssetDetail
            v-if="isShowAssetDetail"
            @closeAssetDetail="closeAssetDetail()"
            :formMode="formMode"
            :assetIdSelected="assetIdSelected"
            @refreshData="getPagingFilterAsset()"
            @showDialog="handleSetupDialog"
            @showLoadingSpinner="showLoadingSpinner"
            @hideLoadingSpinner="hideLoadingSpinner"
        />

        <MISADialog
            :dialogSetup="dialogSetup"
            @handleMainButtonClick="handleMainButtonDialogClick"
            @handleSubButtonClick="handleSubButtonDialogClick"
            @handleOutlineButtonClick="handleOutlineButtonDialogClick"
        />

        <MISALoadingSpinner :isShow="isLoadingSpinner" />
    </div>
</template>
<script>
import AssetDataTables from "./AssetDataTables.vue";
import AssetDetail from "./AssetDetail.vue";
import fixedAssetApi from "@/api/FixedAssetApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";

export default {
    name: "AssetPage",
    components: {
        AssetDataTables,
        AssetDetail,
    },
    data() {
        return {
            pagingFilter: {
                page_size: 10,
                page_index: 1,
                filter: [],
                total_pages: 0,
                total_records: 0,
            },
            filterSearch: {
                filter_field: "fixed_asset_name",
                value: "",
            },
            dialogSetup: {
                typeDialog: this.$_MISAEnum.DialogType.WarningAdd,
                isShow: false,
                dialogText: this.$_MISAResource.VN.Dialog.WarningAdd.Text,
                hasMainButton: true,
                textMainButton: this.$_MISAResource.VN.Dialog.Button.Cancel,
                hasSubButton: true,
                textSubButton: this.$_MISAResource.VN.Dialog.Button.No,
                hasOutlineButton: true,
                textOutlineButton: this.$_MISAResource.VN.Dialog.Button.No,
            },
            isLoadingSpinner: false,
            assetsSelected: [], // Danh sách tài sản được chọn để xóa
            fixedAssets: [], // Danh sách tài sản binding lên datatable
            isShowAssetDetail: false, // Trạng thái show của form chi tiết tài sản
            formMode: this.$_MISAEnum.FormMode.Add, // Form mode hiện tại được sử dụng
            assetIdSelected: "", // ID của tài sản được chọn để edit, duplicate
            departments: [
                { id: 1, text: "Phòng nhân sự" },
                { id: 2, text: "Phòng đào tạo" },
                { id: 3, text: "Phòng hành chính" },
                { id: 4, text: "Phòng mắm tôm" },
            ],
            dataFields: { value: "id", text: "text" },
        };
    },
    methods: {
        /**
         * Cập nhật lại danh sách data theo sự thay đổi của pageSize
         * @param {*} pageSize Số bản ghi trên một trang
         * Author: NDThien 27/07/2023
         */
        handlePageSizeChanged(pageSize) {
            this.pagingFilter.page_size = pageSize;
            this.pagingFilter.page_index = 1; // Reset pageIndex khi thay đổi pageSize
            this.getPagingFilterAsset();
        },
        /**
         * Cập nhật lại danh sách theo pageNumber
         * @param {*} pageNumber Vị trí trang hiện tại
         * Author: NDThien 27/07/2023
         */
        handlePageNumberChanged(pageNumber) {
            this.pagingFilter.page_index = pageNumber;
            this.getPagingFilterAsset();
        },
        /**
         * Open Asset Detail
         * Author: NDThien 25/6/2023
         */
        openAssetDetail(formMode, data) {
            switch (formMode) {
                case this.$_MISAEnum.FormMode.Add:
                    this.formMode = this.$_MISAEnum.FormMode.Add;
                    break;
                case this.$_MISAEnum.FormMode.Edit:
                    this.formMode = this.$_MISAEnum.FormMode.Edit;
                    this.assetIdSelected = data.fixed_asset_id;
                    break;
                case this.$_MISAEnum.FormMode.Duplicate:
                    this.formMode = this.$_MISAEnum.FormMode.Duplicate;
                    this.assetIdSelected = data.fixed_asset_id;
                    break;
                default:
                    break;
            }
            this.isShowAssetDetail = true;
        },
        /**
         * Hiện loading spinner
         * Author: NDThien 24/07/2023
         */
        showLoadingSpinner() {
            this.isLoadingSpinner = true;
        },
        /**
         * Ẩn loading spinner
         * Author: NDThien 24/07/2023
         */
        hideLoadingSpinner() {
            this.isLoadingSpinner = false;
        },
        /**
         * Close Asset Detail
         * Author: NDThien 25/6/2023
         */
        closeAssetDetail() {
            this.isShowAssetDetail = false;
        },
        /**
         * Handle Enter search value input
         * Author: NDThien 27/07/2023
         */
        handleSearchValue() {
            this.getPagingFilterAsset();
        },
        /**
         * Hàm lấy toàn bộ dữ liệu tài sản
         * Author: NDThien 13/07/2023
         */
        async getPagingFilterAsset() {
            try {
                this.fixedAssets = [];
                this.isLoadingDataTable = true;

                this.pagingFilter.filter = [];
                if (this.filterSearch.value) {
                    this.pagingFilter.filter.push(this.filterSearch);
                }

                const res = await fixedAssetApi.pagingFilter(this.pagingFilter);
                this.fixedAssets = res.data.data;
                this.pagingFilter.total_records = res.data.total_records;
                this.isLoadingDataTable = false;
            } catch (error) {
                console.log(`error`, error);
            }
        },
        /**
         * Show dialog cảnh báo khi ấn button hủy của form thêm mới
         * Author: NDThien 17/07/2023
         */
        showDialogAddWarning() {
            this.isShowDialogAddWarning = true;
        },
        /**
         * Xử lý khi ấn nút hủy bỏ của dialog warning Add
         * 1. Đóng dialog warning add
         * 2. Đóng form detail asset
         * Author: NDThien 17/07/2023
         */
        handleCancelDialogWarningAdd() {
            this.handleCloseDialogWarningAdd();
            this.closeAssetDetail();
        },
        /**
         * Lấy các tài sản đang được chọn
         * Author: NDThien 17/07/2023
         */
        getAssetsSelected(assetsSelected) {
            this.assetsSelected = assetsSelected;
        },
        /**
         * Handle hiển thị dialog khi chọn delete tài sản
         * Author: NDThien 17/07/2023
         */
        onClickBtnDelete() {
            // Set up thông tin của dialog
            if (this.assetsSelected.length == 1) {
                // Xóa một tài sản
                this.handleSetupDialog(
                    this.$_MISAEnum.DialogType.WarningDeleteOne
                );
            } else if (this.assetsSelected.length >= 2) {
                // Xóa nhiều tài sản
                this.handleSetupDialog(
                    this.$_MISAEnum.DialogType.WarningDeleteMultiple
                );
            }
        },
        /**
         * Gọi API xóa các tài sản được chọn
         * Author: NDThien 17/07/2023
         */
        deleteMultipleAssetsSeleted() {
            toast.warning("Chức năng xóa đang được phát triển!", {
                position: toast.POSITION.BOTTOM_RIGHT,
                closeButton: false,
                hideProgressBar: true,
                autoClose: 3000,
            });
        },
        /**
         * Xử lý setup dialog để hiển thị
         * @param {*} dialogType - Type của dialog
         * Author: NDThien 23/07/2023
         */
        handleSetupDialog(dialogType) {
            if (dialogType === this.$_MISAEnum.DialogType.WarningAdd) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog: this.$_MISAEnum.DialogType.WarningAdd,
                    dialogText: this.$_MISAResource.VN.Dialog.WarningAdd.Text,
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Cancel,
                    hasSubButton: true,
                    textSubButton: this.$_MISAResource.VN.Dialog.Button.No,
                    hasOutlineButton: false,
                };
            } else if (dialogType === this.$_MISAEnum.DialogType.WarningEdit) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog: this.$_MISAEnum.DialogType.WarningEdit,
                    dialogText: this.$_MISAResource.VN.Dialog.WarningEdit.Text,
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Save,
                    hasSubButton: true,
                    textSubButton: this.$_MISAResource.VN.Dialog.Button.NoSave,
                    hasOutlineButton: true,
                    textOutlineButton:
                        this.$_MISAResource.VN.Dialog.Button.Cancel,
                };
            } else if (
                dialogType === this.$_MISAEnum.DialogType.WarningDeleteOne
            ) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog: this.$_MISAEnum.DialogType.WarningDeleteOne,
                    dialogText: this.$_MISAResource.VN.Dialog.DeleteOne.text(
                        "TS0001 - Máy tính Casio"
                    ),
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Delete,
                    hasSubButton: true,
                    textSubButton: this.$_MISAResource.VN.Dialog.Button.No,
                    hasOutlineButton: false,
                };
            } else if (
                dialogType === this.$_MISAEnum.DialogType.WarningDeleteMultiple
            ) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog:
                        this.$_MISAEnum.DialogType.WarningDeleteMultiple,
                    dialogText:
                        this.$_MISAResource.VN.Dialog.DeleteMultiple.text(
                            this.assetsSelected.length
                        ),
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Delete,
                    hasSubButton: true,
                    textSubButton: this.$_MISAResource.VN.Dialog.Button.No,
                    hasOutlineButton: false,
                };
            } else if (
                dialogType === this.$_MISAEnum.DialogType.InValidStartUsingDate
            ) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog:
                        this.$_MISAEnum.DialogType.InValidStartUsingDate,
                    dialogText:
                        this.$_MISAResource.VN.Dialog.InValidStartUsingDate
                            .Text,
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Close,
                    hasSubButton: false,
                    hasOutlineButton: false,
                };
            } else if (
                dialogType ===
                this.$_MISAEnum.DialogType.InValidDepreciationValue
            ) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog:
                        this.$_MISAEnum.DialogType.InValidDepreciationValue,
                    dialogText:
                        this.$_MISAResource.VN.Dialog.InValidDepreciationValue
                            .Text,
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Close,
                    hasSubButton: false,
                    hasOutlineButton: false,
                };
            } else if (
                dialogType ===
                this.$_MISAEnum.DialogType.InValidDepreciationRate
            ) {
                this.dialogSetup = {
                    isShow: true,
                    typeDialog:
                        this.$_MISAEnum.DialogType.InValidDepreciationRate,
                    dialogText:
                        this.$_MISAResource.VN.Dialog.InValidDepreciationRate
                            .Text,
                    hasMainButton: true,
                    textMainButton: this.$_MISAResource.VN.Dialog.Button.Close,
                    hasSubButton: false,
                    hasOutlineButton: false,
                };
            }
        },
        /**
         * Xử lý click main button dialog
         * Author: NDThien 23/07/2023
         */
        handleMainButtonDialogClick() {
            if (
                this.dialogSetup.typeDialog ===
                this.$_MISAEnum.DialogType.WarningAdd
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
                // 2. Đóng form asset detail
                this.closeAssetDetail();
            } else if (
                this.dialogSetup.typeDialog ===
                this.$_MISAEnum.DialogType.WarningEdit
            ) {
                console.log("OnSAVe in dialog!!!!");
            } else if (
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.WarningDeleteOne ||
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.WarningDeleteMultiple
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
                // Thực hiện xóa
                this.deleteMultipleAssetsSeleted();
            } else if (
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.InValidStartUsingDate ||
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.InValidDepreciationValue ||
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.InValidDepreciationRate
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
            }
        },
        /**
         * Xử lý click sub button dialog
         * Author: NDThien 23/07/2023
         */
        handleSubButtonDialogClick() {
            if (
                this.dialogSetup.typeDialog ===
                this.$_MISAEnum.DialogType.WarningAdd
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
            } else if (
                this.dialogSetup.typeDialog ===
                this.$_MISAEnum.DialogType.WarningEdit
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
                // 2. Đóng form asset detail
                this.closeAssetDetail();
            } else if (
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.WarningDeleteOne ||
                this.dialogSetup.typeDialog ===
                    this.$_MISAEnum.DialogType.WarningDeleteMultiple
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
            }
        },
        /**
         * Xử lý click Outline button dialog
         * Author: NDThien 23/07/2023
         */
        handleOutlineButtonDialogClick() {
            if (
                this.dialogSetup.typeDialog ===
                this.$_MISAEnum.DialogType.WarningEdit
            ) {
                // 1. Đóng dialog
                this.dialogSetup.isShow = false;
            }
        },
    },
    created() {
        // Load data
        this.getPagingFilterAsset();
    },
};
</script>
<style scoped>
@import url(../../../css/layout/content.css);
</style>
