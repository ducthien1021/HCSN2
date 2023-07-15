<template>
    <button class="h-btn__sub" :tabindex="tabindex">
        <slot></slot>
    </button>
</template>

<style scoped>
@import url(./MISAButton.css);
</style>

<script>
export default {
    name: "MISAButtonSub",
    props: {
        // icon truyền vào
        icon: {
            type: String,
            default: "",
        },
        // tabindex truyền vào
        tabindex: {
            type: Number,
            default: 0,
        },
    },
};
</script>
