<template>
    <div class="dialog" v-if="dialogSetup.isShow">
        <div class="dialog__container">
            <div class="dialog__body">
                <div class="dialog__icon"></div>
                <div class="dialog__text" v-html="dialogSetup.dialogText"></div>
            </div>
            <div class="dialog__footer">
                <MISAButton
                    type="outline"
                    :text="dialogSetup.textOutlineButton"
                    v-if="dialogSetup.hasOutlineButton"
                    @click="handleOutlineButtonClick"
                />
                <MISAButton
                    type="sub"
                    :text="dialogSetup.textSubButton"
                    v-if="dialogSetup.hasSubButton"
                    @click="handleSubButtonClick"
                />
                <MISAButton
                    type="main"
                    :text="dialogSetup.textMainButton"
                    v-if="dialogSetup.hasMainButton"
                    @click="handleMainButtonClick"
                />
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: "MISADialog",
    props: {
        dialogSetup: {
            type: Object,
            required: true,
            default: () => ({
                isShow: true, // Trạng thái show của dialog
                dialogText:
                    "<b>Dialog content</b> is here! <i>Can using tag html in here!</i>", // Nội dung của dialog
                hasMainButton: true, // Có main button trong dialog không?
                textMainButton: "Main Button",
                hasSubButton: true, // Có sub button trong dialog không?
                textSubButton: "Sub Button",
                hasOutlineButton: false, // Có outline button trong dialog không?
                textOutlineButton: "Outline Button",
            }),
        },
    },
    data() {
        return {};
    },
    methods: {
        /**
         * Gửi emit ra ngoài để handle khi button outline click
         * Author: NDThien 23/07/2023
         */
        handleOutlineButtonClick() {
            this.$emit("handleOutlineButtonClick");
        },
        /**
         * Gửi emit ra ngoài để handle khi button Sub click
         * Author: NDThien 23/07/2023
         */
        handleSubButtonClick() {
            this.$emit("handleSubButtonClick");
        },
        /**
         * Gửi emit ra ngoài để handle khi button Main click
         * Author: NDThien 23/07/2023
         */
        handleMainButtonClick() {
            this.$emit("handleMainButtonClick");
        },
    },
    mounted() {},
};
</script>
<style scoped>
@import url(../../css/base/dialog.css);
</style>
