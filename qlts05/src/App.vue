<template>
  <PropertyManagementLayout />
</template>

<script>
import PropertyManagementLayout from './layouts/PropertyManagementLayout/PropertyManagementLayout.vue'
export default {
  name: 'App',
  components: {
    PropertyManagementLayout,
  },
  props: {
    msg: String, //
    height: {
      type: Number, default: 200 // height of app
    }
  }
}
</script>

<style>
#app {
  font-family: Roboto, sans-serif;
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}
</style>
