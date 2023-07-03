<template>
  <div class="layout" :style="{ 'grid-template-columns': gridTemplateColumns }">
    <TheHeader />
    <TheSideBar @expandBar="expandBar" />
    <TheMain />
  </div>
</template>

<script>

import TheHeader from './TheHeader.vue'
import TheSideBar from './TheSideBar.vue'
import TheMain from './TheMain.vue'

export default {
  name: 'PropertyManagementLayout',
  components: {
    TheHeader,
    TheSideBar,
    TheMain,
  },
  data() {
    return {
      sidebarWidth: '200px', // độ rộng mặc định của Sidebar
      isSidebarExpand: true, // mặc định Sidebar được mở rộng

    };
  },
  computed: {
    /**
     * Tính toán độ rộng của Main
     * @returns {string} độ rộng của Main
     * Author: PQNAM (29/06/2023)
     */
    gridTemplateColumns() {
      return `${this.sidebarWidth} auto`;
    },
  },
  methods: {
    /**
     * Mở rộng Sidebar
     * Author: PQNAM (29/06/2023)
     */
    expandBar() {
      this.isSidebarExpand = !this.isSidebarExpand;
      this.sidebarWidth = this.isSidebarExpand ? '200px' : '66px';
    },
  },
}
</script>

<style>
.layout {
  height: 100%;
  width: 100%;
  display: grid;
  grid-template-areas:
    "sidebar header"
    "sidebar main";
  grid-template-rows: 44px 1fr;
  grid-template-columns: 200px 1fr;
}
</style>
