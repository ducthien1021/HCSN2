<template>
    <button class="h-btn__main" :tabindex="tabindex">
        <MISAIcon :icon="icon"></MISAIcon>
        <div class="h-btn__main--text"><slot></slot></div>
    </button>
</template>

<style scoped>
@import url(./MISAButton.css);
</style>

<script>
import MISAIcon from "../MISAIcon/MisaIcon.vue";

export default {
    name: "MISAButtonMain",
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
    components: {
        MISAIcon,
    },
};
</script>
