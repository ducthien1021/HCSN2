<template>
    <button :class="buttonClasses" class="h-btn__sub">
        <slot></slot>
        {{ text }}
    </button>
</template>

<style scoped>
@import url(./MISAButton.css);
</style>

<script>
export default {
    props: {
        text: {
            type: String,
            default: "",
        },
        buttonClasses: {
            type: Array,
            default: () => [],
        },
    },
};
</script>
