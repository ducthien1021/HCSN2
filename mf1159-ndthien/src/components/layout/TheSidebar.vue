<template lang="">
    <div class="sidebar" :class="{ 'sidebar--collapse': isCollapseSidebar }">
        <div class="sidebar__top">
            <div class="sidebar__logo"></div>
            <div class="sidebar__text">MISA QLTS</div>
        </div>
        <div class="sidebar__body">
            <router-link to="/cbx" class="menu-item" title="Tổng quan">
                <div class="menu-item__icon icon--general"></div>
                <div class="menu-item__text">Tổng quan</div>
            </router-link>
            <router-link to="asset" class="menu-item" title="Tài sản">
                <div class="menu-item__icon icon--asset"></div>
                <div class="menu-item__text">Tài sản</div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item" title="Tài sản HT-ĐB">
                <div class="menu-item__icon icon--asset-HTDB"></div>
                <div class="menu-item__text">Tài sản HT-ĐB</div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item" title="Công cụ dụng cụ">
                <div class="menu-item__icon icon--tool"></div>
                <div class="menu-item__text">Công cụ dụng cụ</div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item" title="Danh mục">
                <div class="menu-item__icon icon--category"></div>
                <div class="menu-item__text">Danh mục</div>
            </router-link>
            <router-link to="/" class="menu-item" title="Tra cứu">
                <div class="menu-item__icon icon--search"></div>
                <div class="menu-item__text">Tra cứu</div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item" title="Báo cáo">
                <div class="menu-item__icon icon--report"></div>
                <div class="menu-item__text">Báo cáo</div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
        </div>
        <div class="sidebar__bottom">
            <button
                class="sidebar__toggle"
                :class="{
                    'sidebar__toggle--arrow-right': isCollapseSidebar == true,
                    'sidebar__toggle--arrow-left': isCollapseSidebar == false,
                }"
                @click="toogleCollapseSidebar()"
            ></button>
        </div>
    </div>
</template>
<script>
export default {
    name: "TheSidebar",
    data() {
        return {
            isCollapseSidebar: false,
        };
    },
    methods: {
        /**
         * Toggle collapse sidebar
         * Author: NDThien 27/6/2023
         */
        toogleCollapseSidebar() {
            this.isCollapseSidebar = !this.isCollapseSidebar;
            this.$emit("toogleCollapseSidebar"); // Emit để parent thay đổi width main content cho phù hợp với trạng thái sidebar
        },
    },
};
</script>
<style scoped>
@import url(../../css/layout/sidebar.css);
</style>
