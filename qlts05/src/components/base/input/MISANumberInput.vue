<template>
    <div class="input-wrapper">
        <p v-if="hasText">Năm</p>
        <input type="number" :placeholder="placeholder" :max="max" :min="min" />
        <div id="inc-button" class="spinner-button">
            <MISAIcon :pX="this.$_icons.arrowUp.pX" :pY="this.$_icons.arrowUp.pY" :width="this.$_icons.arrowUp.width"
                :height="this.$_icons.arrowUp.height" :scale="this.$_icons.arrowUp.scale" />
        </div>
        <div id="dec-button" class="spinner-button">
            <MISAIcon :pX="this.$_icons.arrowDown.pX" :pY="this.$_icons.arrowDown.pY" :width="this.$_icons.arrowDown.width"
                :height="this.$_icons.arrowDown.height" :scale="this.$_icons.arrowDown.scale" />
        </div>
    </div>
</template>
  
<script>
import MISAIcon from '@/components/base/icon/MISAIcon.vue'
export default {
    name: "MISANumberInput",
    props: {
        maxValue: { type: Number, default: 2024 }, // max value for input
        minValue: { type: Number, default: 2021 }, // min value for input
        hasText: { type: Boolean, default: true }, // has text before input
    },
    computed: {
        /**
         * @returns {string}
         * @description: placeholder for input
         * @example: 2021
         * Author PQNAM (26/06/2023)
         */
        placeholder() {
            return `${this.minValue}`
        },

        /**
         * @returns {string}
         * @description: max value for input
         * @example: 2024
         * Author PQNAM (26/06/2023)
         */
        max() {
            return `${this.maxValue}`
        },

        /**
         * @returns {string}
         * @description: min value for input
         * @example: 2021
         * Author PQNAM (26/06/2023)
         */
        min() {
            return `${this.minValue}`
        },
    },
    components: {
        MISAIcon,
    },
}
</script>
  
<style scoped>
.input-wrapper {
    display: flex;
    align-items: center;
    width: 112px;
    height: 30px;
    box-sizing: border-box;
    background-color: var(--row-hover-color);
    border-radius: 3px;
    justify-content: space-between;
    padding: 8px;
    position: relative;
}

.input-wrapper:hover {
    background-color: var(--row-hover-color);
    cursor: pointer;
}

input {
    border: none;
    outline: none;
    width: 60px;
    text-align: center;
    font-size: 13px;
    font-weight: 700;
    background-color: transparent;
}

input::-webkit-inner-spin-button {
    opacity: 0;
}

input:hover {
    cursor: pointer;
}

p {
    font-size: 13px;
}

.spinner-button {
    position: absolute;
    z-index: 2;
    background-color: transparent;
    width: 10px;
    display: flex;
    align-items: center;
    justify-content: center;
    margin: 0px;
    height: 10px;
    box-sizing: border-box;
    pointer-events: none;
}

#inc-button {
    right: 8px;
    top: 5px;
}

#dec-button {
    right: 8px;
    bottom: 5px;
}
</style>