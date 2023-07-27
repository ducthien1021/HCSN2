<template lang="">
    <div class="popup">
        <div class="popup-form">
            <div class="popup__header">
                <div class="popup__title">Sửa tài sản</div>
                <MISAButton
                    type="btn-icon"
                    icon="close"
                    @click="onClickBtnCloseAssetDetail()"
                />
            </div>
            <div class="popup__body">
                <div class="row">
                    <div class="col--1">
                        <label for="" class="label"
                            >Mã tài sản <span class="require">*</span></label
                        >
                        <input
                            type="text"
                            class="input"
                            ref="fixed_asset_code"
                            tabindex="1"
                            v-model="fixedAsset.fixed_asset_code"
                            @blur="validate('fixed_asset_code')"
                            :class="{
                                'input--error':
                                    errorsValidate.fixed_asset_code != '',
                            }"
                        />
                        <span
                            class="error-msg"
                            v-if="errorsValidate.fixed_asset_code != ''"
                        >
                            {{ errorsValidate.fixed_asset_code }}
                        </span>
                    </div>
                    <div class="col--2">
                        <label for="" class="label"
                            >Tên tài sản <span class="require">*</span></label
                        >
                        <input
                            type="text"
                            class="input"
                            tabindex="2"
                            ref="fixed_asset_name"
                            v-model="fixedAsset.fixed_asset_name"
                            @blur="validate('fixed_asset_name')"
                            :class="{
                                'input--error':
                                    errorsValidate.fixed_asset_name != '',
                            }"
                        />
                        <span
                            class="error-msg"
                            v-if="errorsValidate.fixed_asset_name != ''"
                        >
                            {{ errorsValidate.fixed_asset_name }}
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <label for="" class="label"
                            >Mã bộ phận sử dụng
                            <span class="require">*</span></label
                        >
                        <MISACombobox
                            tabindex="3"
                            ref="department_code"
                            v-model="fixedAsset.department_code"
                            @blur="validate('department_code')"
                            :className="{
                                'cbx--error':
                                    errorsValidate.department_code != '',
                            }"
                            :dataSource="dataSource"
                            :dataFields="dataFields"
                        />
                        <span
                            class="error-msg"
                            v-if="errorsValidate.department_code != ''"
                        >
                            {{ errorsValidate.department_code }}
                        </span>
                    </div>
                    <div class="col--2">
                        <label for="" class="label">Tên bộ phận sử dụng</label>
                        <input type="text" class="input" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <label for="" class="label"
                            >Mã loại tài sản
                            <span class="require">*</span></label
                        >
                        <MISACombobox
                            tabindex="4"
                            ref="fixed_asset_category_code"
                            v-model="fixedAsset.fixed_asset_category_code"
                            @blur="validate('fixed_asset_category_code')"
                            :className="
                                errorsValidate.fixed_asset_category_code != ''
                                    ? 'cbx--error'
                                    : ''
                            "
                            :dataSource="dataSource"
                            :dataFields="dataFields"
                        />
                        <span
                            class="error-msg"
                            v-if="
                                errorsValidate.fixed_asset_category_code != ''
                            "
                        >
                            {{ errorsValidate.fixed_asset_category_code }}
                        </span>
                    </div>
                    <div class="col--2">
                        <label for="" class="label">Tên loại tài sản</label>
                        <input type="text" class="input" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <label for="" class="label"
                            >Số lượng <span class="require">*</span></label
                        >
                        <input
                            type="text"
                            class="input text-right"
                            tabindex="5"
                            ref="quantity"
                        />
                    </div>
                    <div class="col--1">
                        <label for="" class="label">Nguyên giá</label>
                        <input
                            type="text"
                            class="input text-right"
                            tabindex="6"
                            ref="cost"
                        />
                    </div>
                    <div class="col--1">
                        <label for="" class="label">Số năm sử dụng</label>
                        <input
                            type="text"
                            class="input text-right"
                            tabindex="7"
                            ref="life_time"
                        />
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <label for="" class="label"
                            >Tỉ lệ hao mòn (%)
                            <span class="require">*</span></label
                        >
                        <input
                            type="text"
                            class="input text-right"
                            tabindex="8"
                            ref="depreciation_rate"
                        />
                    </div>
                    <div class="col--1">
                        <label for="" class="label"
                            >Giá trị hao mòn năm
                            <span class="require">*</span></label
                        >
                        <input
                            type="text"
                            class="input text-right"
                            tabindex="9"
                            ref="depreciation_value"
                        />
                    </div>
                    <div class="col--1">
                        <label for="" class="label">Năm theo dõi</label>
                        <input
                            type="text"
                            class="input text-right"
                            disabled
                            ref="production_year"
                        />
                    </div>
                </div>
                <div class="row">
                    <div class="col--1">
                        <label for="" class="label"
                            >Ngày mua <span class="require">*</span></label
                        >
                        <el-date-picker
                            type="date"
                            value-format="YYYY-MM-DD"
                            :placeholder="'DD/MM/YYYY'"
                            tabindex="10"
                            ref="purchase_date"
                        />
                    </div>
                    <div class="col--1">
                        <label for="" class="label"
                            >Ngày bắt đầu sử dụng
                            <span class="require">*</span></label
                        >
                        <el-date-picker
                            type="date"
                            value-format="YYYY-MM-DD"
                            :placeholder="'DD/MM/YYYY'"
                            tabindex="11"
                            ref="tracked_year"
                        />
                    </div>
                </div>
            </div>
            <div class="popup__footer">
                <MISAButton
                    type="outline"
                    text="Hủy"
                    tabindex="13"
                    @keydown.tab.prevent="setFocusFirstInput()"
                    @click="onClickBtnCloseAssetDetail()"
                />
                <MISAButton type="main" text="Lưu" tabindex="12" />
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: "AssetDetail",
    data() {
        return {
            fixedAsset: {}, // Thông tin tài sản
            /**
             * Role validate đặc thù
             */
            validations: {
                fixed_asset_code: { Required: true },
                fixed_asset_name: { Required: true },
                fixed_asset_category_code: { Required: true },
                tracked_year: {},
                department_code: { Required: true },
                cost: { Required: true },
                life_time: { Required: true },
                quantity: { Required: true },
            },
            /**
             * Thông tin lỗi
             */
            errorsValidate: {
                fixed_asset_code: "",
                fixed_asset_name: "",
                fixed_asset_category_code: "",
                tracked_year: "",
                department_code: "",
                cost: "",
                life_time: "",
                quantity: "",
            },
            dataSource: [
                { id: 1, text: "Phòng nhân sự" },
                { id: 2, text: "Phòng đào tạo" },
                { id: 3, text: "Phòng hành chính" },
                { id: 4, text: "Phòng mắm tôm" },
            ],
            dataFields: { value: "id", text: "text" },
        };
    },
    created() {
        this.setFocusFirstInput();
    },
    methods: {
        /**
         * Handle onclick btn close in form
         * Author: NDThien 26/6/2023
         */
        onClickBtnCloseAssetDetail() {
            this.$emit("closeAssetDetail", true);
        },
        /**
         * Set focus first input
         * Author: NDThien 26/6/2023
         */
        setFocusFirstInput() {
            this.$nextTick(function () {
                this.$refs.fixed_asset_code.focus();
            });
        },
        /**
         * Validate field in form
         * Author: NDThien 26/6/2023
         * @param {*} ref: ref of field
         */
        validate(ref) {
            for (const key in this.validations[ref]) {
                let functionName = `validate${key}`;
                this[functionName](ref);
            }
        },
        /**
         * Validate required field in form
         * Author: NDThien 26/6/2023
         * @param {*} ref: ref of field
         */
        validateRequired(ref) {
            if (!this.fixedAsset[ref]) {
                this.errorsValidate[ref] = "Giá trị này không được để trống";
                return true;
            } else {
                this.errorsValidate[ref] = "";
                return false;
            }
        },
    },
};
</script>
<style>
@import url(../../../css/base/popup.css);
@import url(../../../css/base/el-date-picker.css);
</style>
