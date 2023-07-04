<template>
    <button class="h-btn__main" :style="style">
        <MISAIcon :icon="icon"></MISAIcon>
        <div class="h-btn__main--text"><slot></slot></div>
    </button>
</template>

<style scoped>
@import url(./MISAButton.css);
</style>

<script>
import MISAIcon from "../MISAIcon/MisaIcon.vue";

const components = {
    MISAIcon,
};

export default {
    name: "MISAButtonMain",
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
    components,
};
</script>
