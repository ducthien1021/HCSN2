<template>
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
            required: false,
            default: "",
        },
        type: {
            // type is value: "main", "outline", "btn-icon"
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
            // Size của btn-icon: 36 (px) và 16 (px)
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
