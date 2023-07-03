<template>
    <header class="header">
        <div class="header__left">
            <h1>Danh sách tài sản</h1>
        </div>
        <div class="header__right">
            <div class="address">
                <p>Sở tài chính</p>
            </div>
            <div class="number-input">
                <MISANumberInput />
            </div>
            <div class="header__icon">
                <MISAIcon class="icon" :pX="this.$_icons.bell.pX" :pY="this.$_icons.bell.pY"
                    :width="this.$_icons.bell.width" :height="this.$_icons.bell.height" />
                <MISAIcon class="icon" :pX="this.$_icons.toggle.pX" :pY="this.$_icons.toggle.pY" />
                <MISAIcon class="icon" :pX="this.$_icons.help.pX" :pY="this.$_icons.help.pY" />
                <MISAIcon class="icon" :pX="this.$_icons.user.pX" :pY="this.$_icons.user.pY" />
            </div>
            <div class="more-options">
                <MISAIcon class="icon" :pX="this.$_icons.more.pX" :pY="this.$_icons.more.pY"
                    :width="this.$_icons.more.width" :height="this.$_icons.more.height" :scale="this.$_icons.more.scale" />
            </div>
        </div>
    </header>
</template>

<script>
import MISAIcon from '@/components/base/icon/MISAIcon.vue'
import MISANumberInput from '@/components/base/input/MISANumberInput.vue';
export default {
    components: { MISAIcon, MISANumberInput },
    name: 'TheHeader',
}
</script>

<style scoped>
.header {
    grid-area: header;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 16px 20px;
    box-sizing: border-box;
}

.header__left {
    display: flex;
    align-items: center;

}

h1 {
    font-size: 13px;
    font-weight: 700;

}

.header__right {
    display: flex;
    align-items: center;
    justify-content: flex-end;
}

.address p {
    font-size: 13px;
    color: #001031;
}

.address {
    margin-right: 24px;
}

.number-input {
    margin-right: 24px;
}

.header__icon {
    display: flex;
    column-gap: 20px;
}

.icon:hover {
    cursor: pointer;
    background-color: var(--btn-border-color);
}
</style>