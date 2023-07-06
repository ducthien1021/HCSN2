<template>
    <div class="h-form">
        <div class="h-form__container">
            <div class="h-form__header">
                <div class="h-form__title">{{ title }}</div>
                <div class="h-form__close" @click="closeForm"></div>
            </div>
            <div class="h-form__main">
                <div class="h-form__row">
                    <div class="h-form__assetid">
                        <MISATextfield
                            ref="firstInput"
                            label="Mã tài sản"
                            :required="true"
                            v-model="assetsData.AssetID"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__name">
                        <MISATextfield
                            label="Tên tài sản"
                            :required="true"
                            placeholder="Nhập tên tài sản"
                            v-model="assetsData.Name"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__departmentid">
                        <MISADropdown
                            label="Mã bộ phận sử dụng"
                            :required="true"
                            v-model="assetsData.Department"
                            text="Chọn mã bộ phận sử dụng"
                            :dataList="this.$_MISAResources.department"
                            :iconRight="'expand'"
                        ></MISADropdown>
                    </div>
                    <div class="h-form__department">
                        <MISATextfield label="Tên bộ phận sử dụng" :disable="true"></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__assetid">
                        <MISADropdown
                            label="Mã loại tài sản"
                            :required="true"
                            v-model="assetsData.Type"
                            text="Chọn mã loại tài sản"
                            :dataList="this.$_MISAResources.department"
                            :iconRight="'expand'"
                        ></MISADropdown>
                    </div>
                    <div class="h-form__asset">
                        <MISATextfield label="Tên Loại tài sản" :disable="true"></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__amount">
                        <MISATextfield
                            label="Số lượng"
                            :required="true"
                            v-model="assetsData.Amount"
                            :textRight="true"
                            icon="dropdown"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__originalprice">
                        <MISATextfield
                            label="Nguyên giá"
                            :required="true"
                            v-model="assetsData.TheOriginalPrice"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__yearsuse">
                        <MISATextfield
                            label="Số năm sử dụng"
                            :required="true"
                            v-model="assetsData.YearUse"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__atrophy--percents">
                        <MISATextfield
                            label="Tỷ lệ hao mòn (%)"
                            :required="true"
                            v-model="assetsData.atrophyPercents"
                            :textRight="true"
                            icon="dropdown"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__atrophy">
                        <MISATextfield
                            label="Giá trị hao mòn năm"
                            :required="true"
                            v-model="assetsData.atrophy"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__yeartracking">
                        <MISATextfield
                            label="Năm theo dõi"
                            :disable="true"
                            v-model="year"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__daybuy">
                        <MISATextfield
                            label="Ngày mua"
                            :required="true"
                            v-model="date"
                            icon="calendar"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__dayuse">
                        <MISATextfield
                            label="Ngày sử dụng"
                            :required="true"
                            v-model="date"
                            icon="calendar"
                        ></MISATextfield>
                    </div>
                    <div></div>
                </div>
            </div>
            <div class="h-form__footer">
                <div class="h-footer__btn--cancel">
                    <MISAButtonSub @click="closeForm">Huỷ</MISAButtonSub>
                </div>
                <div class="h-footer__btn--save">
                    <MISAButtonMain @click="saveForm">Lưu</MISAButtonMain>
                </div>
            </div>
        </div>
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

export default {
    name: "MISAForm",
    watch: {
        // khi dataObject thay đổi thì gán cho assetsData
        dataObject: function () {
            this.assetsData = this.dataObject;
        },
        formMode: function () {
            // focus vào input đầu tiên khi mở form
            setTimeout(() => {
                this.$refs.firstInput.focus();
            }, 0);
        },
    },
    data() {
        return {
            assetsData: this.dataObject, // dữ liệu tài sản
        };
    },
    components: {
        MISATextfield,
        MISAButtonMain,
        MISAButtonSub,
        MISADropdown,
    },
    props: {
        // tiêu đề của form
        title: {
            type: String,
            default: "",
        },
        // dữ liệu tài sản truyền vào
        dataObject: {
            type: Object,
            default: {
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
            },
        },
        // chế độ form add/edit
        formMode: {
            type: Number,
        },
    },
    computed: {
        // lấy ngày hiện tại
        date() {
            return this.dateHandler(new Date());
        },
        // lấy năm hiện tại
        year() {
            return new Date().getFullYear().toString();
        },
    },
    methods: {
        //đang xử lý
        closeForm: function () {
            this.$emit("close-form");
        },
        saveForm: function () {
            this.$emit("close-form");
        },
    },
};
</script>
