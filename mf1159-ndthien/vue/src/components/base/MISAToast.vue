<template>
    <div class="toast">
        <div class="toast__icon" :class="`icon--${type}`"></div>
        <div class="toast__content">{{ toastContent }}</div>
    </div>
</template>
<script>
export default {
    name: "MISAToast",
    props: {
        type: {
            type: String,
            required: false,
            default: "success",
        },
        toastContent: {
            type: String,
            required: false,
            default: "Toast content is here!",
        },
    },
    mounted() {
        setTimeout(() => {}, 3000);
    },
};
</script>
<style scoped></style>
