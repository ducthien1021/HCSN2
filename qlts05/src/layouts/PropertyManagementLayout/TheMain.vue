<template>
  <div class="main">
    <router-view></router-view>
  </div>
</template>
  
<script>


export default {
  name: 'TheMain',
  components: {

  },
}
</script>
  
<style>
.main {
  grid-area: main;
  background-color: #f4f7ff;
}
</style>