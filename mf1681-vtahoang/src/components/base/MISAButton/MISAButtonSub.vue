<template>
    <button class="h-btn__sub">
        <slot></slot>
    </button>
</template>

<style scoped>
@import url(./MISAButton.css);
</style>

<script>
export default {
    props: {
        // icon truyền vào
        icon: {
            type: String,
            default: "",
        },
    },
};
</script>
