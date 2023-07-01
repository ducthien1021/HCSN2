<template>
    <button :class="buttonClasses" class="h-btn__main">
        <div v-if="icon" :class="buttonClassesIcon" class="h-btn__main--icon"></div>
        <div :class="buttonClassesText" class="h-btn__main--text">{{ text }}</div>
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
        buttonClassesIcon: {
            type: Array,
            default: () => [],
        },
        buttonClassesText: {
            type: Array,
            default: () => [],
        },
        icon: {
            type: Boolean,
            default: false,
        },
    },
};
</script>
