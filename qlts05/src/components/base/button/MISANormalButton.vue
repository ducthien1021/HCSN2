<template>
    <button class="misa-normal-button">
        <slot></slot>
    </button>
</template>
  
<script>
export default {
    name: 'MISANormalButton',

};
</script>
  
<style scoped>
.misa-normal-button {
    height: 36px;
    border-radius: 3px;
    background-color: var(--basic-color);
    box-shadow: 0 2px 6px rgba(0, 0, 0, .16);
    padding: 12px;
    color: #fff;
    border: none;
    outline: none;
    box-sizing: border-box;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 13px;
}

.misa-normal-button:hover {
    background-color: var(--btn-hover-color);
    cursor: pointer;
}

.misa-normal-button:active {
    background-color: var(--btn-active-color);
}
</style>