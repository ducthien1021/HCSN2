<template>
    <div class="h-form">
        <div class="h-form__container">
            <div class="h-form__header">
                <div class="h-form__title">{{ tittle }}</div>
                <div class="h-form__close" @click="toggleForm"></div>
            </div>
            <div class="h-form__main">
                <div class="h-form__row">
                    <div class="h-form__assetid">
                        <MISATextfield
                            label="Mã tài sản"
                            :required="true"
                            value="TS00001"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__name">
                        <MISATextfield
                            label="Tên tài sản"
                            :required="true"
                            placeholder="Nhập tên tài sản"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__departmentid">
                        <MISATextfield
                            label="Mã bộ phận sử dụng"
                            :required="true"
                            placeholder="Chọn mã bộ phận sử dụng"
                            :expandIcon="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__department">
                        <MISATextfield label="Tên bộ phận sử dụng" :disable="true"></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__assetid">
                        <MISATextfield
                            label="Mã loại tài sản"
                            :required="true"
                            placeholder="Chọn mã loại tài sản"
                            :expandIcon="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__asset">
                        <MISATextfield label="Tên Loại tài sản" :disable="true"></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__amount">
                        <MISATextfield
                            label="Mã loại tài sản"
                            :required="true"
                            value="01"
                            :textRight="true"
                            :dropDownIcon="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__originalprice">
                        <MISATextfield
                            label="Nguyên giá"
                            :required="true"
                            value="0"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__yearsuse">
                        <MISATextfield
                            label="Số năm sử dụng"
                            :required="true"
                            value="0"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__atrophy--percents">
                        <MISATextfield
                            label="Tỷ lệ hao mòn (%)"
                            :required="true"
                            value="0"
                            :textRight="true"
                            :dropDownIcon="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__atrophy">
                        <MISATextfield
                            label="Giá trị hao mòn năm"
                            :required="true"
                            value="0"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__yeartracking">
                        <MISATextfield
                            label="Năm theo dõi"
                            :disable="true"
                            :value="year"
                            :textRight="true"
                        ></MISATextfield>
                    </div>
                </div>
                <div class="h-form__row">
                    <div class="h-form__daybuy">
                        <MISATextfield
                            label="Ngày mua"
                            :required="true"
                            :value="date"
                            :calenderIcon="true"
                        ></MISATextfield>
                    </div>
                    <div class="h-form__dayuse">
                        <MISATextfield
                            label="Ngày sử dụng"
                            :required="true"
                            :value="date"
                            :calenderIcon="true"
                        ></MISATextfield>
                    </div>
                    <div></div>
                </div>
            </div>
            <div class="h-form__footer">
                <MISAButtonSub
                    :buttonClasses="['h-footer__button', 'h-footer__button--cancel']"
                    text="Huỷ"
                    @click="toggleForm"
                ></MISAButtonSub>
                <MISAButtonMain
                    :buttonClasses="['h-footer__button', 'h-footer__button--save']"
                    text="Lưu"
                    @click="toggleForm"
                ></MISAButtonMain>
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

/**
 * Date handler
 * Author: vtahoang - (20/06/2023)
 */
function dateHandler(date) {
    try {
        if (date != null) {
            date = new Date(date);
            let month = date.getMonth() + 1;
            return `${date.getDate()}/${month}/${date.getFullYear()}`;
        }
        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

const computed = {
    date() {
        return dateHandler(new Date());
    },
    year() {
        return new Date().getFullYear().toString();
    },
};

export default {
    components: {
        MISATextfield,
        MISAButtonMain,
        MISAButtonSub,
    },
    props: {
        tittle: {
            type: String,
            default: "",
        },
    },
    computed,
    methods: {
        toggleForm: function () {
            this.$emit("toggle-form");
        },
    },
};
</script>
