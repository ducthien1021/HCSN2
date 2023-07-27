<template>
    <div class="sidebar" :class="{ 'sidebar--collapse': isCollapseSidebar }">
        <div class="sidebar__top">
            <div class="sidebar__logo"></div>
            <div class="sidebar__text">MISA QLTS</div>
        </div>
        <div class="sidebar__body">
            <router-link to="/dialog" class="menu-item">
                <div class="menu-item__icon icon--general"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.General.Text }}
                </div>
            </router-link>
            <router-link to="asset" class="menu-item">
                <div class="menu-item__icon icon--asset"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.Asset.Text }}
                </div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link
                to="/"
                class="menu-item"
                :title="sidebarResource.AssetRoadInfrastructure.Tooltip"
            >
                <div class="menu-item__icon icon--asset-HTDB"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.AssetRoadInfrastructure.Text }}
                </div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item">
                <div class="menu-item__icon icon--tool"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.Tool.Text }}
                </div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item">
                <div class="menu-item__icon icon--category"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.Category.Text }}
                </div>
            </router-link>
            <router-link to="/" class="menu-item">
                <div class="menu-item__icon icon--search"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.Search.Text }}
                </div>
                <div class="menu-item__icon icon--dropdown"></div>
            </router-link>
            <router-link to="/" class="menu-item">
                <div class="menu-item__icon icon--report"></div>
                <div class="menu-item__text">
                    {{ sidebarResource.Report.Text }}
                </div>
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
            sidebarResource: this.$_MISAResource.VN.Sidebar,
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
