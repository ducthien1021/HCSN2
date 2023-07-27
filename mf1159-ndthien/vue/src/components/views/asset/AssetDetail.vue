<template>
    <div class="popup">
        <div class="popup-form">
            <div class="popup__header">
                <div class="popup__title">{{ assetDetailTitle }}</div>
                <MISAButton
                    type="btn-icon"
                    icon="close"
                    @click="onClickCancelAssetDetail()"
                />
            </div>
            <div class="popup__body">
                <div class="row">
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.fixed_asset_code
                                    .Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.fixed_asset_code
                                    ? errorsValidate.fixed_asset_code
                                    : ''
                            "
                        >
                            <MISAInput
                                :tabindex="1"
                                :placeholder="
                                    $_MISAResource.VN.AssetForm.fixed_asset_code
                                        .Placeholder
                                "
                                v-model="fixedAsset.fixed_asset_code"
                                ref="fixed_asset_code"
                                @blur="validateRequired('fixed_asset_code')"
                                :isError="errorsValidate.fixed_asset_code != ''"
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--2">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.fixed_asset_name
                                    .Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.fixed_asset_name
                                    ? errorsValidate.fixed_asset_name
                                    : ''
                            "
                        >
                            <MISAInput
                                :tabindex="2"
                                :placeholder="
                                    $_MISAResource.VN.AssetForm.fixed_asset_name
                                        .Placeholder
                                "
                                v-model="fixedAsset.fixed_asset_name"
                                ref="fixed_asset_name"
                                @blur="validateRequired('fixed_asset_name')"
                                :isError="errorsValidate.fixed_asset_name != ''"
                            />
                        </MISAFormGroup>
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.department_code
                                    .Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.department_code
                                    ? errorsValidate.department_code
                                    : ''
                            "
                        >
                            <MISACombobox
                                :placeholder="
                                    $_MISAResource.VN.AssetForm.department_code
                                        .Placeholder
                                "
                                :tabindex="3"
                                v-model="fixedAsset.department_code"
                                ref="department_code"
                                :dataSource="departments"
                                :dataFields="dataFieldsDepartments"
                                @blur="validateRequired('department_code')"
                                :isError="errorsValidate.department_code != ''"
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--2">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.department_name
                                    .Label
                            "
                        >
                            <MISAInput
                                :isDisabled="true"
                                v-model="fixedAsset.department_name"
                            />
                        </MISAFormGroup>
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm
                                    .fixed_asset_category_code.Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.fixed_asset_category_code
                                    ? errorsValidate.fixed_asset_category_code
                                    : ''
                            "
                        >
                            <MISACombobox
                                :placeholder="
                                    $_MISAResource.VN.AssetForm
                                        .fixed_asset_category_code.Placeholder
                                "
                                :tabindex="4"
                                v-model="fixedAsset.fixed_asset_category_code"
                                ref="fixed_asset_category_code"
                                :dataSource="fixedAssetCategories"
                                :dataFields="dataFieldsfixedAssetCategories"
                                @blur="
                                    validateRequired(
                                        'fixed_asset_category_code'
                                    )
                                "
                                :isError="
                                    errorsValidate.fixed_asset_category_code !=
                                    ''
                                "
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--2">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm
                                    .fixed_asset_category_name.Label
                            "
                        >
                            <MISAInput
                                :isDisabled="true"
                                v-model="fixedAsset.fixed_asset_category_name"
                            />
                        </MISAFormGroup>
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <MISAFormGroup
                            :label="$_MISAResource.VN.AssetForm.quantity.Label"
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.quantity
                                    ? errorsValidate.quantity
                                    : ''
                            "
                        >
                            <MISAInput
                                :tabindex="5"
                                :hasSuffix="true"
                                v-model="fixedAsset.quantity"
                                ref="quantity"
                                textAlign="right"
                                :formatCurrency="true"
                                @blur="validateRequired('quantity')"
                                :isError="errorsValidate.quantity != ''"
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--1">
                        <MISAFormGroup
                            :label="$_MISAResource.VN.AssetForm.cost.Label"
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.cost ? errorsValidate.cost : ''
                            "
                        >
                            <MISAInput
                                :tabindex="6"
                                v-model="fixedAsset.cost"
                                ref="cost"
                                textAlign="right"
                                :formatCurrency="true"
                                @blur="validateRequired('cost')"
                                :isError="errorsValidate.cost != ''"
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--1">
                        <MISAFormGroup
                            :label="$_MISAResource.VN.AssetForm.life_time.Label"
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.life_time
                                    ? errorsValidate.life_time
                                    : ''
                            "
                        >
                            <MISAInput
                                :tabindex="7"
                                v-model="fixedAsset.life_time"
                                ref="life_time"
                                textAlign="right"
                                :formatCurrency="true"
                                @blur="validateRequired('life_time')"
                                :isError="errorsValidate.life_time != ''"
                            />
                        </MISAFormGroup>
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.depreciation_rate
                                    .Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.depreciation_rate
                                    ? errorsValidate.depreciation_rate
                                    : ''
                            "
                        >
                            <MISAInputNumber
                                v-model="fixedAsset.depreciation_rate"
                                ref="depreciation_rate"
                                :tabindex="8"
                                textAlign="right"
                                :precision="2"
                                :min="0"
                                :max="100"
                                @blur="validateRequired('depreciation_rate')"
                                :isError="
                                    errorsValidate.depreciation_rate != ''
                                "
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.depreciation_value
                                    .Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.depreciation_value
                                    ? errorsValidate.depreciation_value
                                    : ''
                            "
                        >
                            <MISAInput
                                v-model="fixedAsset.depreciation_value"
                                ref="depreciation_value"
                                :tabindex="9"
                                textAlign="right"
                                :min="0"
                                :formatCurrency="true"
                                @blur="validateRequired('depreciation_value')"
                                :isError="
                                    errorsValidate.depreciation_value != ''
                                "
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.tracked_year.Label
                            "
                        >
                            <MISAInput
                                :isDisabled="true"
                                v-model="fixedAsset.tracked_year"
                                ref="tracked_year"
                                textAlign="right"
                                :tabindex="10"
                                :isNumberOnly="true"
                            />
                        </MISAFormGroup>
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.purchase_date.Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.purchase_date
                                    ? errorsValidate.purchase_date
                                    : ''
                            "
                        >
                            <MISADatePicker
                                :tabindex="11"
                                placeholder="dd/MM/yyyy"
                                value-format="DD/MM/YYYY"
                                format="DD/MM/YYYY"
                                v-model="fixedAsset.purchase_date"
                                ref="purchase_date"
                                @blur="validateRequired('purchase_date')"
                                :isError="errorsValidate.purchase_date != ''"
                            />
                        </MISAFormGroup>
                    </div>
                    <div class="col--1">
                        <MISAFormGroup
                            :label="
                                $_MISAResource.VN.AssetForm.start_using_date
                                    .Label
                            "
                            :isRequired="true"
                            :errorMsg="
                                errorsValidate.start_using_date
                                    ? errorsValidate.start_using_date
                                    : ''
                            "
                        >
                            <MISADatePicker
                                :tabindex="12"
                                placeholder="dd/MM/yyyy"
                                valueFormat="DD/MM/YYYY"
                                format="DD/MM/YYYY"
                                v-model="fixedAsset.start_using_date"
                                ref="start_using_date"
                                @blur="validateRequired('start_using_date')"
                                :isError="errorsValidate.start_using_date != ''"
                            />
                        </MISAFormGroup>
                    </div>
                </div>
            </div>
            <div class="popup__footer">
                <MISAButton
                    type="sub"
                    :text="$_MISAResource.VN.Button.Cancel"
                    :tabindex="14"
                    @keydown.tab.prevent="setFocusFirstInput()"
                    @click="onClickCancelAssetDetail()"
                />
                <MISAButton
                    ref="btnSave"
                    type="main"
                    :text="$_MISAResource.VN.Button.Save"
                    :tabindex="13"
                    @click="onClickSave()"
                    :disabled="isDisabledBtnSave"
                />
            </div>
        </div>
    </div>
</template>
<script>
import fixedAssetApi from "@/api/FixedAssetApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";

export default {
    name: "AssetDetail",
    props: {
        formMode: {
            type: Number,
            required: true,
            default: null,
        },
        assetIdSelected: {
            type: String,
            required: false,
            default: null,
        },
    },
    computed: {
        /**
         * Sinh title cho form theo form mode
         * Author: NDThien 13/07/2023
         */
        assetDetailTitle() {
            switch (this.formMode) {
                case this.$_MISAEnum.FormMode.Add:
                    return this.$_MISAResource.VN.AssetForm.Title.Add;
                case this.$_MISAEnum.FormMode.Edit:
                    return this.$_MISAResource.VN.AssetForm.Title.Edit;
                case this.$_MISAEnum.FormMode.Duplicate:
                    return this.$_MISAResource.VN.AssetForm.Title.Add;
            }
            return this.$_MISAResource.AssetForm.Title.Add;
        },
        /**
         * Kiểm tra dữ liệu có bị thay đổi hay không
         */
        isDataChanged() {
            return (
                JSON.stringify(this.fixedAsset) !==
                JSON.stringify(this.fixedAssetOldValue)
            );
        },
    },
    data() {
        return {
            isDisabledBtnSave: false, // Trạng thái disable của button save
            fixedAssetOldValue: {
                fixed_asset_code: "",
                quantity: 0,
                depreciation_rate: 0,
                cost: 0,
                life_time: 0,
                tracked_year: new Date().getFullYear(),
                purchase_date: new Date().toLocaleDateString("en-GB"),
                start_using_date: new Date().toLocaleDateString("en-GB"),
                department_code: "",
            }, // Thông tin tài sản clone cũ để so sánh sự thay đổi dữ liệu
            fixedAsset: {
                fixed_asset_id: "",
                fixed_asset_code: "",
                fixed_asset_name: "",
                quantity: "0",
                depreciation_rate: 0,
                depreciation_value: "0",
                cost: "0",
                life_time: "0",
                tracked_year: `${new Date().getFullYear()}`,
                purchase_date: new Date().toLocaleDateString("en-GB"),
                start_using_date: new Date().toLocaleDateString("en-GB"),
                department_id: "",
                department_code: "",
                department_name: "",
                fixed_asset_category_id: "",
                fixed_asset_category_code: "",
                fixed_asset_category_name: "",
            }, // Thông tin tài sản
            validations: {
                fixed_asset_code: { Required: true },
                fixed_asset_name: { Required: true },
                department_code: { Required: true },
                fixed_asset_category_code: { Required: true },
                quantity: { Required: true },
                cost: { Required: true },
                life_time: { Required: true },
                depreciation_rate: { Required: true },
                depreciation_value: { Required: true },
                purchase_date: { Required: true },
                start_using_date: { Required: true },
            },
            /**
             * Thông tin lỗi
             */
            errorsValidate: {
                fixed_asset_code: "",
                fixed_asset_name: "",
                department_code: "",
                fixed_asset_category_code: "",
                quantity: "",
                cost: "",
                life_time: "",
                depreciation_rate: "",
                depreciation_value: "",
                tracked_year: "",
                purchase_date: "",
                start_using_date: "",
            },
            departments: [
                {
                    id: "142cb08f-7c31-21fa-8e90-67245e8b283e",
                    code: "ID000",
                    text: "Phòng sản xuất",
                },
                {
                    id: "469b3ece-744a-45d5-957d-e8c757976496",
                    code: "ID001",
                    text: "Phòng đào tạo",
                },
                {
                    id: "4e272fc4-7875-78d6-7d32-6a1673ffca7c",
                    code: "ID002",
                    text: "Phòng nhân sự",
                },
                {
                    id: "17120d02-6ab5-3e43-18cb-66948daf6128",
                    code: "ID003",
                    text: "Phòng hành chính",
                },
            ],
            dataFieldsDepartments: { value: "code", text: "code" },
            fixedAssetCategories: [
                {
                    id: "148ed882-32b8-218e-9c20-39c2f00615e8",
                    code: "DTDD",
                    text: "Điện thoại di động",
                },
                {
                    id: "25c6c36e-1668-7d10-6e09-bf1378b8dc91",
                    code: "BPMT",
                    text: "Bàn phím máy tính",
                },
                {
                    id: "354f1b13-17bf-1b52-87d5-ba100c6f7bce",
                    code: "MTXT",
                    text: "Máy tính xách tay",
                },
                {
                    id: "3700cc49-55b5-69ea-4929-a2925c0f334d",
                    code: "CMT",
                    text: "Chuột máy tính",
                },
            ],
            dataFieldsfixedAssetCategories: { value: "code", text: "code" },
        };
    },
    created() {
        this.setFocusFirstInput();
        this.loadData();
        this.isDisabledBtnSave = false;
    },
    methods: {
        /**
         * Hiện loading spinner
         * Author: NDThien 24/07/2023
         */
        showLoadingSpinner() {
            this.$emit("showLoadingSpinner");
        },
        /**
         * Ẩn loading spinner
         * Author: NDThien 24/07/2023
         */
        hideLoadingSpinner() {
            this.$emit("hideLoadingSpinner");
        },
        /**
         * Hàm load data cho form detail asset
         * Author: NDThien 14/07/2023
         */
        async loadData() {
            this.showLoadingSpinner();
            try {
                if (this.formMode == this.$_MISAEnum.FormMode.Add) {
                    // Lấy mã code mới
                    await this.getNewCodeFixedAssset();
                    // Clone giá trị của tài sản để theo so sánh sự thay đổi (không dùng gán)
                    this.fixedAssetOldValue = { ...this.fixedAsset };
                } else if (this.formMode == this.$_MISAEnum.FormMode.Edit) {
                    const res = await fixedAssetApi.getById(
                        this.assetIdSelected
                    );
                    this.fixedAsset = res.data;
                    this.fixedAsset.purchase_date =
                        this.$_MISAFunctions.formatDate(
                            this.fixedAsset.purchase_date
                        );
                    this.fixedAsset.start_using_date =
                        this.$_MISAFunctions.formatDate(
                            this.fixedAsset.start_using_date
                        );
                    this.fixedAsset.depreciation_value = Math.round(
                        this.fixedAsset.depreciation_rate * this.fixedAsset.cost
                    );
                } else if (
                    this.formMode == this.$_MISAEnum.FormMode.Duplicate
                ) {
                    // Lấy data tài sản về
                    const res = await fixedAssetApi.getById(
                        this.assetIdSelected
                    );
                    this.fixedAsset = res.data;
                    this.fixedAsset.purchase_date =
                        this.$_MISAFunctions.formatDate(
                            this.fixedAsset.purchase_date
                        );
                    this.fixedAsset.start_using_date =
                        this.$_MISAFunctions.formatDate(
                            this.fixedAsset.start_using_date
                        );
                    this.fixedAsset.depreciation_value = Math.round(
                        this.fixedAsset.depreciation_rate * this.fixedAsset.cost
                    );
                    // Lấy mã code mới
                    this.getNewCodeFixedAssset();
                }
            } catch (error) {
                console.log(`error`, error);
            }
            this.hideLoadingSpinner();
        },
        /**
         * Xử lý save data form detail
         * Author: NDThien 17/07/2023
         */
        async onClickSave() {
            let isValidData = this.validateAll();
            if (isValidData) {
                if (this.formMode == this.$_MISAEnum.FormMode.Add) {
                    try {
                        this.fixedAsset.purchase_date =
                            this.$_MISAFunctions.convertToDate(
                                this.fixedAsset.purchase_date
                            );
                        this.fixedAsset.start_using_date =
                            this.$_MISAFunctions.convertToDate(
                                this.fixedAsset.start_using_date
                            );
                        this.fixedAsset.cost =
                            this.$_MISAFunctions.convertCurrencyToNumber(
                                this.fixedAsset.cost
                            );
                        this.fixedAsset.life_time =
                            this.$_MISAFunctions.convertCurrencyToNumber(
                                this.fixedAsset.life_time
                            );
                        const res = await fixedAssetApi.insert(this.fixedAsset);
                        if (res.data == 1) {
                            this.closeAssetDetail();
                            this.isDisabledBtnSave = true;
                            this.$emit("refreshData");
                            toast.success(
                                this.$_MISAResource.VN.Toast.InsertSuccess,
                                {
                                    position: toast.POSITION.BOTTOM_RIGHT,
                                    closeButton: false,
                                    hideProgressBar: true,
                                    autoClose: 3000,
                                }
                            );
                        }
                    } catch (error) {
                        toast.error(error.response.data.UserMessage, {
                            position: toast.POSITION.BOTTOM_RIGHT,
                            closeButton: false,
                            hideProgressBar: true,
                            autoClose: 3000,
                        });
                    }
                } else if (this.formMode == this.$_MISAEnum.FormMode.Edit) {
                    this.fixedAsset.purchase_date =
                        this.$_MISAFunctions.convertToDate(
                            this.fixedAsset.purchase_date
                        );
                    this.fixedAsset.start_using_date =
                        this.$_MISAFunctions.convertToDate(
                            this.fixedAsset.start_using_date
                        );
                    this.fixedAsset.cost =
                        this.$_MISAFunctions.convertCurrencyToNumber(
                            this.fixedAsset.cost
                        );
                    this.fixedAsset.life_time =
                        this.$_MISAFunctions.convertCurrencyToNumber(
                            this.fixedAsset.life_time
                        );
                    const res = await fixedAssetApi.update(
                        this.fixedAsset.fixed_asset_id,
                        this.fixedAsset
                    );
                    if (res.data == 1) {
                        this.closeAssetDetail();
                        this.isDisabledBtnSave = true;
                        this.$emit("refreshData");
                        toast.success(
                            this.$_MISAResource.VN.Toast.UpdateSuccess,
                            {
                                position: toast.POSITION.BOTTOM_RIGHT,
                                closeButton: false,
                                hideProgressBar: true,
                                autoClose: 3000,
                            }
                        );
                    }
                } else if (
                    this.formMode == this.$_MISAEnum.FormMode.Duplicate
                ) {
                    this.fixedAsset.purchase_date =
                        this.$_MISAFunctions.convertToDate(
                            this.fixedAsset.purchase_date
                        );
                    this.fixedAsset.start_using_date =
                        this.$_MISAFunctions.convertToDate(
                            this.fixedAsset.start_using_date
                        );
                    this.fixedAsset.cost =
                        this.$_MISAFunctions.convertCurrencyToNumber(
                            this.fixedAsset.cost
                        );
                    this.fixedAsset.life_time =
                        this.$_MISAFunctions.convertCurrencyToNumber(
                            this.fixedAsset.life_time
                        );
                    const res = await fixedAssetApi.insert(this.fixedAsset);
                    if (res.data == 1) {
                        this.closeAssetDetail();
                        this.isDisabledBtnSave = true;
                        this.$emit("refreshData");
                        toast.success(
                            this.$_MISAResource.VN.Toast.InsertSuccess,
                            {
                                position: toast.POSITION.BOTTOM_RIGHT,
                                closeButton: false,
                                hideProgressBar: true,
                                autoClose: 3000,
                            }
                        );
                    }
                }
            }
        },
        /**
         * Handle onclick btn cancel or close in form
         * Author: NDThien 26/6/2023
         */
        onClickCancelAssetDetail() {
            if (this.isDataChanged) {
                // Xử lý theo form mode để show dialog cảnh báo phù hợp
                if (this.formMode == this.$_MISAEnum.FormMode.Add) {
                    this.$emit(
                        "showDialog",
                        this.$_MISAEnum.DialogType.WarningAdd
                    );
                } else if (this.formMode == this.$_MISAEnum.FormMode.Edit) {
                    this.$emit(
                        "showDialog",
                        this.$_MISAEnum.DialogType.WarningEdit
                    );
                } else if (
                    this.formMode == this.$_MISAEnum.FormMode.Duplicate
                ) {
                    this.$emit(
                        "showDialog",
                        this.$_MISAEnum.DialogType.WarningAdd
                    );
                }
            } else {
                // Nếu data không thay đổi -> đóng form
                this.closeAssetDetail();
            }
        },
        /**
         * Close form asset detail
         * Author: NDThien 17/07/2023
         */
        closeAssetDetail() {
            this.$emit("closeAssetDetail", true);
        },
        /**
         * Set focus first input
         * Author: NDThien 26/6/2023
         */
        setFocusFirstInput() {
            this.$nextTick(function () {
                this.$el.querySelector('input[tabindex = "1"]').focus();
            });
        },
        /**
         * Set focus input error đầu tiên
         * Author: NDThien 17/07/2023
         */
        setFocusInputError() {
            for (const key in this.errorsValidate) {
                if (this.error[key] !== "") {
                    this.$refs[key].focus();
                    break;
                }
            }
        },
        /**
         * Get new code fixed asset code
         * Author: NDThien 24/07/2023
         */
        async getNewCodeFixedAssset() {
            try {
                const newCode = await fixedAssetApi.getNewCode();
                this.fixedAsset.fixed_asset_code = newCode.data;
            } catch (error) {
                console.log(error);
            }
        },
        /**
         * Validate required field in form
         * Author: NDThien 26/6/2023
         * @param {*} field field of Object
         */
        validateRequired(field) {
            if (!this.fixedAsset[field]) {
                this.errorsValidate[field] =
                    this.$_MISAResource.VN.AssetForm[field].EmptyMsgError;
                return false;
            } else {
                this.errorsValidate[field] = "";
                return true;
            }
        },
        /**
         * Validate ngày mua phải luôn <= ngày sử dụng
         * Author: NDThien 26/07/2023
         */
        validateStartUsingDate() {
            return (
                new Date(
                    this.$_MISAFunctions.convertToDate(
                        this.fixedAsset.purchase_date
                    )
                ) <=
                new Date(
                    this.$_MISAFunctions.convertToDate(
                        this.fixedAsset.start_using_date
                    )
                )
            );
        },
        /**
         * Validate giá trị hao mòn/khấu hao năm <= nguyên giá
         * Author: NDThien 26/07/2023
         */
        validateDepreciationValue() {
            return (
                this.$_MISAFunctions.convertCurrencyToNumber(
                    this.fixedAsset.depreciation_value
                ) <=
                this.$_MISAFunctions.convertCurrencyToNumber(
                    this.fixedAsset.cost
                )
            );
        },
        /**
         * Validate tỉ lệ hao mòn == 1/số năm sử dụng
         * Math.round(num * 100) / 100: Làm tròn num với 2 chữ số sau dấu phẩy
         * Author: NDThien 26/07/2023
         */
        validateDepreciationRate() {
            return (
                this.fixedAsset.depreciation_rate ==
                Math.round((1 / this.fixedAsset.life_time) * 100)
            );
        },
        /**
         * Validate toàn bộ thông tin trên form
         * Author: NDThien 17/07/2023
         */
        validateAll() {
            // Validate required fields
            for (const propName in this.validations) {
                this.validateRequired(propName);
            }

            if (!this.validateStartUsingDate()) {
                this.$emit(
                    "showDialog",
                    this.$_MISAEnum.DialogType.InValidStartUsingDate
                );
                return false;
            }

            if (!this.validateDepreciationRate()) {
                this.$emit(
                    "showDialog",
                    this.$_MISAEnum.DialogType.InValidDepreciationRate
                );
                return false;
            }

            if (!this.validateDepreciationValue()) {
                this.$emit(
                    "showDialog",
                    this.$_MISAEnum.DialogType.InValidDepreciationValue
                );
                return false;
            }

            return true;
        },
    },
    watch: {
        /**
         * Theo dõi sự thay đổi của tỉ lệ hao mòn -> Tính toán lại số tiền
         * @param {*} newVal Giá trị mới
         * Author: NDThien 17/07/2023
         */
        "fixedAsset.depreciation_rate": function (newVal) {
            this.fixedAsset.depreciation_value = Math.round(
                (newVal / 100) *
                    this.$_MISAFunctions.convertCurrencyToNumber(
                        this.fixedAsset.cost
                    )
            );
        },
        /**
         * Theo dõi sự thay đổi của nguyên giá -> Tính toán lại số tiền
         * Cập nhật object fixedAsset
         * @param {*} newVal Giá trị mới
         * Author: NDThien 17/07/2023
         */
        "fixedAsset.cost": function (newVal) {
            this.fixedAsset.depreciation_value = Math.round(
                (this.fixedAsset.depreciation_rate / 100) *
                    this.$_MISAFunctions.convertCurrencyToNumber(newVal)
            );
        },
        /**
         * Theo dõi sự thay đổi của mã phòng ban -> Điền tên phòng ban
         * @param {*} newVal Giá trị mới
         * Author: NDThien 17/07/2023
         */
        "fixedAsset.department_code": function (newVal) {
            if (newVal != "") {
                const index = this.departments.findIndex(
                    (item) => item.code == newVal
                );
                this.fixedAsset.department_name =
                    this.departments[index]["text"];
                this.fixedAsset.department_id = this.departments[index]["id"];
            }
        },
        /**
         * Theo dõi sự thay đổi của mã loại tài sản -> Điền tên loại tài sản
         * Cập nhật object fixedAsset
         * @param {*} newVal
         * Author: NDThien 17/07/2023
         */
        "fixedAsset.fixed_asset_category_code": function (newVal) {
            if (newVal != "") {
                const index = this.fixedAssetCategories.findIndex(
                    (item) => item.code == newVal
                );
                this.fixedAsset.fixed_asset_category_name =
                    this.fixedAssetCategories[index]["text"];
                this.fixedAsset.fixed_asset_category_id =
                    this.fixedAssetCategories[index]["id"];
            }
        },
    },
};
</script>
<style scoped>
@import url(../../../css/base/popup.css);
</style>
