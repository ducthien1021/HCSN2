<template>
    <div class="h-dialog">
        <div class="h-dialog__header"></div>
        <div class="h-dialog__body">
            <MISAIcon :icon="'warning'"></MISAIcon>
            <div class="h-body__message">{{ message }}</div>
        </div>
        <div class="h-dialog__footer">
            <div class="h-footer__btn" @click="back">
                <MISAButtonSub>Không</MISAButtonSub>
            </div>
            <div class="h-footer__btn" @click="cancelForm">
                <MISAButtonMain>Huỷ bỏ</MISAButtonMain>
            </div>
        </div>
    </div>
</template>

<style scoped>
@import url("./MISADialog.css");
</style>

<script>
import MISAIcon from "../MISAIcon/MISAIcon.vue";
import MISAButtonMain from "../MISAButton/MISAButtonMain.vue";
import MISAButtonSub from "../MISAButton/MISAButtonSub.vue";

export default {
    name: "MISADialog",
    components: {
        MISAIcon,
        MISAButtonSub,
        MISAButtonMain,
    },
    data() {
        return {};
    },
    props: {
        // tiêu đề dialog
        message: {
            type: String,
            default: "",
        },
        // loaị form hiện dialog (add, edit, delete)
        formMode: {
            type: String,
            default: "add",
        },
    },
    methods: {
        // hàm trở về trang trước
        back() {
            this.$emit("back");
        },
        // hàm huỷ bỏ form
        cancelForm() {
            this.$emit("cancel-form");
        },
    },
};
</script>
