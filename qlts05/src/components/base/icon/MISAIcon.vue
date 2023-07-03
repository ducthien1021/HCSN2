<template>
    <div class="icon-wrapper" :style="boxStyle">
        <span class="icon" :style="style"></span>
    </div>
</template>
  
<script>
export default {
    name: 'MISAIcon',
    props: {
        pX: { type: String }, //tọa độ x của icon trong sprite
        pY: { type: String }, //tọa độ y của icon trong sprite
        width: { type: String, default: '18' }, //chiều rộng mặc định 18px
        height: { type: String, default: '18' }, //chiều cao mặc định 18px
        color: { type: String, default: 'transparent' }, //màu nền mặc định là trong suốt
        scale: { type: String, default: '1.3' }, //tỉ lệ mặc định là 1.3
        boxWidth: { type: String, default: '24' }, //chiều rộng box mặc định 24px
        boxHeight: { type: String, default: '24' },//chiều cao box mặc định 24px
        filter: { type: String, default: 'none' },//filter mặc định là none
    },
    computed: {
        /**
         * @description: Tạo style cho icon
         * 
         * @returns {Object} style
         * Author: PQNAM (26/06/2023)
         */
        style() {
            return {
                backgroundSize: 'cover',
                width: `${this.width}px`,
                height: `${this.height}px`,
                background: `url(${this.$_imgUrl}) ${this.pX}px ${this.pY}px`,
                backgroundColor: `${this.color}`,
                transform: `scale(${this.scale})`,
                filter: `${this.filter}`,
            }
        },

        /**
         * @description: Tạo style cho box chứa icon
         * 
         * @returns {Object} style
         * Author: PQNAM (26/06/2023)
         */
        boxStyle() {
            return {
                width: `${this.boxWidth}px`,
                height: `${this.boxHeight}px`,
            }
        }
    },
}
</script>
  
<style scoped>
.icon-wrapper {
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: 50%;
}
</style>