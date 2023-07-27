<template>
    <div class="loading-wrapper" v-if="isShow">
        <div class="loading-spinner"></div>
    </div>
</template>
<script>
export default {
    props: {
        isShow: {
            type: Boolean,
            required: false,
            default: false,
        },
    },
};
</script>
<style scoped>
.loading-wrapper {
    position: fixed;
    background-color: rgba(255, 255, 255, 0.1);
    width: 100vw;
    height: 100vh;
    z-index: 4;
    top: 0;
    left: 0;
}
.loading-spinner {
    position: absolute;
    top: 50%;
    left: 50%;
    width: 50px;
    padding: 8px;
    aspect-ratio: 1;
    border-radius: 50%;
    background: #1aa4c8;
    --_m: conic-gradient(#0000 10%, #000), linear-gradient(#000 0 0) content-box;
    -webkit-mask: var(--_m);
    mask: var(--_m);
    -webkit-mask-composite: source-out;
    mask-composite: subtract;
    animation: s3 1s infinite linear;
}

@keyframes s3 {
    to {
        transform: rotate(1turn);
    }
}
</style>
