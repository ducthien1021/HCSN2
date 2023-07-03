<template>
    <div class="side-bar">
        <div class="side-bar__top">
            <div class="bar__logo">
                <MISAIcon :pX="this.$_icons.logo.pX" :pY="this.$_icons.logo.pY" :width="this.$_icons.logo.width"
                    :height="this.$_icons.logo.height" :boxHeight="this.$_icons.logo.boxHeight"
                    :boxWidth="this.$_icons.logo.boxWidth" :scale="this.$_icons.logo.scale" />
            </div>
            <div class="bar__title" v-if="isExpanded">
                <h1>MISA QLTS</h1>
            </div>
        </div>
        <div class="side-bar__nav">
            <!-- Các thẻ nav -->
            <div class="nav-item" v-for="(nav, index) in navs" :key="index" @click="toggleActive(nav)"
                :style="nav.isActive ? 'background-color: #1aa4c8;' : 'background-color: transparent;'"
                @mouseover="nav.isHover = true" @mouseout="nav.isHover = false">
                <router-link :to=nav.toLink class="nav-link-wrapper">
                    <div class="nav-link">
                        <div class="nav-item__icon">
                            <MISAIcon :pX="nav.isHover || nav.isActive ? nav.aicon.pX : nav.icon.pX"
                                :pY="nav.isHover || nav.isActive ? nav.aicon.pY : nav.icon.pY"
                                :width="nav.isHover || nav.isActive ? nav.aicon.width : nav.icon.width"
                                :height="nav.isHover || nav.isActive ? nav.aicon.height : nav.icon.height" :scale="1"
                                :filter="nav.isHover || nav.isActive ? 'none' : 'var(--filter-color)'" />
                        </div>
                        <div class="nav-item__title" v-if="isExpanded">
                            <p :style="nav.isHover || nav.isActive ? 'color: white' : 'color: #556476'">{{ nav.title }}</p>
                        </div>
                    </div>
                    <div class="nav-item__more" v-if="isExpanded && nav.hasChild">
                        <MISAIcon :pX="this.$_icons.moreDown.pX" :pY="this.$_icons.moreDown.pY"
                            :width="this.$_icons.moreDown.width" :height="this.$_icons.moreDown.height"
                            :boxHeight="this.$_icons.moreDown.boxHeight" :boxWidth="this.$_icons.moreDown.boxWidth"
                            :scale="this.$_icons.moreDown.scale"
                            :filter="nav.isHover || nav.isActive ? 'none' : 'var(--filter-color)'" />
                    </div>

                </router-link>


            </div>

        </div>
        <div class="side-bar__footer">
            <!-- Nội dung footer -->
            <div class="footer__item" @click="expandBar">
                <MISAIcon :pX="isExpanded ? this.$_icons.expand.pX : this.$_icons.collapse.pX" :pY="this.$_icons.expand.pY"
                    :width="this.$_icons.expand.width" :height="this.$_icons.expand.height" />
            </div>
        </div>
    </div>
</template>

<script>
import MISAIcon from '@/components/base/icon/MISAIcon.vue';

export default {
    name: 'TheSideBar',
    components: {
        MISAIcon,
    },
    data() {
        return {
            isExpanded: true, // Trạng thái mở rộng của side bar
            navs: [ // Các nav item
                {
                    icon: {
                        pX: -21, // Vị trí x của icon
                        pY: -153, // Vị trí y của icon
                        width: 22, // Chiều rộng của icon
                        height: 22, // Chiều cao của icon
                    },
                    aicon: {
                        pX: -22,
                        pY: -198,
                        width: 20,
                        height: 21,
                    },
                    title: 'Tổng quan',
                    hasChild: false,
                    isActive: false,
                    isHover: false,
                    toLink: '/',
                },
                {
                    icon: {
                        pX: -65,
                        pY: -153,
                        width: 22,
                        height: 23,
                    },
                    aicon: {
                        pX: -65,
                        pY: -197,
                        width: 22,
                        height: 23,
                    },
                    title: 'Tài sản',
                    hasChild: true,
                    isActive: false,
                    isHover: false,
                    toLink: '/property-management',
                },
                {
                    icon: {
                        pX: -110,
                        pY: -153,
                        width: 21,
                        height: 23,
                    },
                    aicon: {
                        pX: -110,
                        pY: -197,
                        width: 21,
                        height: 22,
                    },
                    title: 'Tài sản HT-ĐB',
                    hasChild: true,
                    isActive: false,
                    isHover: false,
                    toLink: '/property',
                },
                {
                    icon: {
                        pX: -153,
                        pY: -153,
                        width: 22,
                        height: 22,
                    },
                    aicon: {
                        pX: -153,
                        pY: -197,
                        width: 22,
                        height: 22,
                    },
                    title: 'Công cụ dụng cụ',
                    hasChild: true,
                    isActive: false,
                    isHover: false,
                    toLink: '/tool',
                },
                {
                    icon: {
                        pX: -197,
                        pY: -155,
                        width: 22,
                        height: 18,
                    },
                    aicon: {
                        pX: -198,
                        pY: -200,
                        width: 22,
                        height: 17,
                    },
                    title: 'Danh mục',
                    hasChild: false,
                    isActive: false,
                    isHover: false,
                    toLink: '/about',
                },
                {
                    icon: {
                        pX: -241,
                        pY: -153,
                        width: 22,
                        height: 22,
                    },
                    aicon: {
                        pX: -240,
                        pY: -197,
                        width: 23,
                        height: 23,
                    },
                    title: 'Tra cứu',
                    hasChild: true,
                    isActive: false,
                    isHover: false,
                    toLink: '/contact'
                },
                {
                    icon: {
                        pX: -329,
                        pY: -153,
                        width: 22,
                        height: 22,
                    },
                    aicon: {
                        pX: -330,
                        pY: -198,
                        width: 20,
                        height: 20,
                    },
                    title: 'Báo cáo',
                    hasChild: true,
                    isActive: false,
                    isHover: false,
                    toLink: '/login',
                },
            ]
        };
    },
    methods: {
        /**
         * Mở rộng thanh sidebar
         * @returns {void}
         * @emits expandBar
         * Author: PQNAM (29/06/2023)
         */
        expandBar() {
            this.isExpanded = !this.isExpanded;
            this.$emit('expandBar');
        },

        /**
         * 
         * @param {*} nav
         * @returns {void}
         * Author: PQNAM (29/06/2023) 
         */
        toggleActive(nav) {
            for (let i = 0; i < this.navs.length; i++) {
                if (this.navs[i] !== nav) {
                    this.navs[i].isActive = false;
                }
            }
            nav.isActive = !nav.isActive;
        },
    },
};
</script>

<style>
.side-bar {
    height: 100%;
    background-color: var(--sidebar-bg-color);
    grid-area: sidebar;
    box-sizing: border-box;
    display: block;
    position: relative;
    transition: width 0.25s ease;
}

.side-bar.expanded {
    transform: translateX(0);
}

.side-bar.collapsed {
    transform: translateX(-134px);
}

.side-bar__top {
    display: flex;
    align-items: center;
    color: #fff;
    box-sizing: border-box;
    height: 66px;
    box-sizing: border-box;
    padding: 11px;
    width: 100%;
}

.bar__title {
    margin-left: 11px;
    height: 100%;
    display: flex;
    align-items: center;
}

.bar__title h1 {
    font-size: 20px;
    font-weight: 700;
    margin: 0;

}

.bar__logo {
    width: 44px;
    height: 100%;
    box-sizing: border-box;
    display: flex;
    align-items: center;
    justify-content: center;
}

.side-bar__nav {

    box-sizing: border-box;
    width: 100%;
    display: block;
}

.nav-item {
    display: flex;
    align-items: center;
    cursor: pointer;
    height: 40px;
    box-sizing: border-box;
    border-radius: 6px;
    padding: 8px 10px 8px 10px;
    justify-content: space-between;
    margin: 0 11px 0 11px;
}

.nav-item:hover {
    background-color: #0582a2 !important;
}

.nav-link-wrapper {
    display: flex;
    align-items: center;
    justify-content: space-between;
    width: 100%;
}

.nav-link {
    display: flex;
    align-items: center;
}

.nav-item__title {
    color: #556476;
    font-size: 13px;
    margin-left: 8px;
}

.side-bar__footer {
    width: 100%;
    height: 44px;
    box-sizing: border-box;
    padding: 10px;
    display: flex;
    align-items: center;
    justify-content: flex-end;
    position: absolute;
    bottom: 0;
    left: 0;
    border-top: 1px solid #263950;
}

.side-bar__footer .footer__item {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 44px;
    height: 100%;
    box-sizing: border-box;
    cursor: pointer;
    filter: var(--filter-color);
}

.side-bar__footer .footer__item:hover {
    filter: none;

}</style>