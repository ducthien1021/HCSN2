<template>
    <div class="h-textfield">
        <label>{{ label }} <span v-if="required">*</span></label>
        <div v-if="expandIcon" class="h-textfield__icon h-textfield__icon--expand"></div>
        <div v-if="dropDownIcon" class="h-textfield__icon h-textfield__icon--dropdown"></div>
        <div v-if="calenderIcon" class="h-textfield__icon h-textfield__icon--calender"></div>
        <input :textRight="textRight" type="text" :placeholder="placeholder" :value="value" :disabled="disable" />
    </div>
</template>

<style scoped>
@import url(./MISATextfield.css);
</style>

<script>
export default {
    props: {
        label: {
            type: String,
            default: "",
        },
        placeholder: {
            type: String,
            default: "",
        },
        required: {
            type: Boolean,
            default: false,
        },
        value: {
            type: String,
            default: "",
        },
        disable: {
            type: Boolean,
            default: false,
        },
        textRight: {
            type: Boolean,
            default: false,
        },
        dropDownIcon: {
            type: Boolean,
            default: false,
        },
        expandIcon: {
            type: Boolean,
            default: false,
        },
        calenderIcon: {
            type: Boolean,
            default: false,
        },
    },
};
</script>
