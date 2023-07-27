<template lang="">
    <button
        :class="[
            type == 'btn-icon'
                ? `btn-icon btn-icon--${size} btn-icon--${icon}`
                : `btn btn--${type}`,
        ]"
        :tabindex="tabindex"
    >
        <i v-if="icon != ''" :class="`icon--${icon}`"></i>
        {{ text }}
    </button>
</template>
<script>
export default {
    name: "MISAButton",
    props: {
        text: {
            type: String,
            required: true,
            default: "",
        },
        type: {
            type: String,
            required: true,
            default: "main",
        },
        tabindex: {
            type: Number,
            required: false,
            default: -1,
        },
        icon: {
            type: String,
            required: false,
            default: "",
        },
        size: {
            type: Number,
            required: false,
            default: 36,
        },
    },
    data() {
        return {};
    },
    computed: {},
};
</script>
<style>
@import url(../../css/base/button.css);
</style>
