<template>
    <div class="h-form" tabindex="-1" @change="isChange = true">
        <div class="h-form__container">
            <div class="h-form__header">
                <div class="h-form__title">{{ title }}</div>
                <div class="h-form__close" @click="closeForm"></div>
            </div>
            <div class="h-form__main">
                <div class="h-form__row">
                    <div class="h-form__assetid">
                        <MISATextfield
                            :tabindex="1"
                            ref="firstInput"
                            label="Mã tài sản"
                            :required="true"
                            v-model="assetData.AssetID"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__name">
                        <MISATextfield
                            :tabindex="2"
                            ref="name"
                            label="Tên tài sản"
                            :required="true"
                            placeholder="Nhập tên tài sản"
                            v-model="assetData.Name"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__departmentid">
                        <MISADropdown
                            :tabindex="3"
                            ref="department"
                            label="Mã bộ phận sử dụng"
                            :required="true"
                            v-model="assetData.Department"
                            text="Chọn mã bộ phận sử dụng"
                            :iconRight="'expand'"
                            :dataList="Object.keys(this.$_MISAResources.department)"
                        ></MISADropdown>
                    </div>
                    <div class="h-form__department">
                        <MISATextfield
                            label="Tên bộ phận sử dụng"
                            :disable="true"
                            v-model="this.$_MISAResources.department[assetData.Department]"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__assetid">
                        <MISADropdown
                            :tabindex="4"
                            ref="type"
                            label="Mã loại tài sản"
                            :required="true"
                            v-model="assetData.Type"
                            text="Chọn mã loại tài sản"
                            :iconRight="'expand'"
                            :dataList="typeList"
                        ></MISADropdown>
                    </div>
                    <div class="h-form__asset">
                        <MISATextfield label="Tên Loại tài sản" :disable="true"></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__amount">
                        <MISATextfield
                            :tabindex="5"
                            ref="amount"
                            label="Số lượng"
                            :required="true"
                            v-model="assetData.Amount"
                            :textRight="true"
                            icon="up_down_arrows"
                            :number="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__originalprice">
                        <MISATextfield
                            :tabindex="6"
                            ref="originalprice"
                            label="Nguyên giá"
                            :required="true"
                            v-model="assetData.TheOriginalPrice"
                            :textRight="true"
                            :number="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__yearsuse">
                        <MISATextfield
                            :tabindex="7"
                            ref="yearsuse"
                            label="Số năm sử dụng"
                            :required="true"
                            v-model="assetData.YearUse"
                            :textRight="true"
                            :number="true"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__atrophy--percents">
                        <MISATextfield
                            :tabindex="8"
                            ref="atrophyPercents"
                            label="Tỷ lệ hao mòn (%)"
                            :required="true"
                            v-model="assetData.atrophyPercents"
                            :textRight="true"
                            icon="up_down_arrows"
                            :number="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__atrophy">
                        <MISATextfield
                            :tabindex="9"
                            ref="atrophy"
                            label="Giá trị hao mòn năm"
                            :required="true"
                            v-model="assetData.atrophy"
                            :textRight="true"
                            :number="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__yeartracking">
                        <MISATextfield
                            :tabindex="10"
                            label="Năm theo dõi"
                            :disable="true"
                            v-model="assetData.YearTracking"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__daybuy">
                        <MISADatePicker
                            :tabindex="11"
                            label="Ngày mua"
                            :required="true"
                            v-model="assetData.daybuy"
                            icon="calendar"
                            ref="daybuy"
                        ></MISADatePicker>
                    </div>
                    <div class="h-form__dayuse">
                        <MISADatePicker
                            :tabindex="12"
                            label="Ngày sử dụng"
                            :required="true"
                            v-model="assetData.dayuse"
                            icon="calendar"
                            ref="dayuse"
                        ></MISADatePicker>
                    </div>
                    <div></div>
                </div>
            </div>
            <div class="h-form__footer">
                <div class="h-footer__btn--cancel">
                    <MISAButtonSub :tabindex="14" @click="closeForm">Huỷ</MISAButtonSub>
                </div>
                <div class="h-footer__btn--save">
                    <MISAButtonMain :tabindex="13" @click="saveForm">Lưu</MISAButtonMain>
                </div>
            </div>
        </div>
        <MISADialog
            :message="diaglogMessage"
            v-if="showDialog"
            @back="hideDialog"
            @cancel-form="cancelForm"
        ></MISADialog>
    </div>
</template>

<style scoped>
@import url(./MISAForm.css);
</style>

<script>
import MISATextfield from "../MISATextfield/MISATextfield.vue";
import MISAButtonMain from "../MISAButton/MISAButtonMain.vue";
import MISAButtonSub from "../MISAButton/MISAButtonSub.vue";
import MISADropdown from "../MISADropdown/MISADropdown.vue";
import MISADatePicker from "../MISADatePicker/MISADatePicker.vue";
import MISADialog from "../MISADialog/MISADialog.vue";

export default {
    name: "MISAForm",
    watch: {
        dataObject: function () {
            this.assetData = this.dataObject;
        },
    },
    mounted() {
        // focus vào input đầu tiên khi mở form
        setTimeout(() => {
            this.$refs.firstInput.focus();
        }, 0);
    },
    data() {
        let assetData;
        if (this.dataObject) {
            assetData = this.dataObject;
            if (this.formMode == this.$_MISAEnum.form.formMode.duplicate)
                assetData.AssetID = this.makeid(10);
        } else
            assetData = {
                AssetID: "TS00001",
                Accumulated: null,
                Amount: 1,
                Department: null,
                Name: null,
                Remaining: {
                    type: Number,
                    default: null,
                },
                TheOriginalPrice: 0,
                Type: null,
                id: null,
                YearUse: 0,
                atrophyPercents: 0,
                atrophy: 0,
                daybuy: new Date(),
                dayuse: new Date(),
                YearTracking: 2023,
            };
        return {
            assetData,
            status: true,
            title: this.$_MISAResources.formTitle[this.formMode],
            diaglogMessage: this.$_MISAResources.dialogMessage[this.formMode],
            showDialog: false,
            isChange: false,
        };
    },
    components: {
        MISATextfield,
        MISAButtonMain,
        MISAButtonSub,
        MISADropdown,
        MISADatePicker,
        MISADialog,
    },
    props: {
        dataObject: {
            type: Object,
            default: null,
        },
        formMode: {
            type: Number,
        },
        typeList: {
            type: Array,
            default: ["Tài sản cố định", "Tài sản dễ dàng cháy nổ", "Tài sản khác"],
        },
    },
    computed: {},
    methods: {
        closeForm: function () {
            if (this.isChange) {
                this.showDialog = true;
            } else {
                this.$emit("close-form");
            }
        },
        hideDialog: function () {
            this.showDialog = false;
        },
        cancelForm: function () {
            this.$emit("close-form");
        },
        saveForm: function () {
            this.status = true;
            for (let [key, value] of Object.entries(this.$refs)) {
                if (value.isValid) {
                    value.isValid();
                    this.status = this.status && value.isValid();
                }
            }
            if (this.status) {
                this.$emit("save-form");
            }
        },
    },
};
</script>
