<template>
    <button class="misa-normal-button">
        <slot></slot>
    </button>
</template>
  
<script>
export default {
    name: 'MISAIconButton',
};
</script>
  
<style scoped>
.misa-normal-button {
    height: 36px;
    width: 36px;
    border-radius: 3px;
    background-color: #ffffff;
    box-shadow: 0 2px 6px rgba(0, 0, 0, .16);
    padding: 6px;
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
    background-color: #f6f6f6;
    cursor: pointer;
}

.misa-normal-button:active {
    background-color: #e4e2e2;
}
</style>