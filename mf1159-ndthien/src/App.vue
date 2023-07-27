<template>
    <div class="page">
        <TheSidebar
            @toogleCollapseSidebar="isCollapseSidebar = !isCollapseSidebar"
        ></TheSidebar>
        <div
            :class="
                isCollapseSidebar
                    ? 'sidebar-collapsed-main'
                    : 'sidebar-expanded-main'
            "
        >
            <TheHeader />
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
import TheSidebar from "./components/layout/TheSidebar.vue";
import TheHeader from "./components/layout/TheHeader.vue";

export default {
    name: "App",
    components: {
        TheSidebar,
        TheHeader,
    },
    data() {
        return {
            isCollapseSidebar: false,
        };
    },
};
</script>

<style scoped>
@import url(./css/main.css);
</style>
