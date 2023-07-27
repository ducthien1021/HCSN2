<template>
    <tr v-for="i in 3" :key="i">
        <td v-for="n in 11" :key="n">
            <div class="loader"></div>
        </td>
    </tr>
</template>
<script>
export default {
    name: "MISALoadingTable",
};
</script>
<style>
.loader {
    background-color: #ededed;
    height: 18px;
    border-radius: 4px;
    width: 100%;
}

td .loader {
    background-color: #ededed;
    background: linear-gradient(
            100deg,
            rgba(255, 255, 255, 0) 40%,
            rgba(255, 255, 255, 0.5) 50%,
            rgba(255, 255, 255, 0) 60%
        )
        #ededed;
    background-size: 200% 100%;
    background-position-x: 180%;
    animation: 1s loading ease-in-out infinite;
}

@keyframes loading {
    to {
        background-position-x: -30%;
    }
}
</style>
