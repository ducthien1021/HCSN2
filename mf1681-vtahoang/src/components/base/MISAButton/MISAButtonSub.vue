<template>
    <button class="h-btn__sub" :style="style">
        <slot></slot>
    </button>
</template>

<style scoped>
@import url(./MISAButton.css);
</style>

<script>
export default {
    props: {
        icon: {
            type: String,
            default: "",
        },
        style: {
            type: Object,
            default: {},
        },
    },
};
</script>
