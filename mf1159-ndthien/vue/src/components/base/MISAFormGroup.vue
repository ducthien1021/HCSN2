<template>
    <div>
        <label for="" class="label" v-if="label != ''"
            >{{ label }} <span v-if="isRequired" class="require">*</span>
        </label>
        <slot></slot>
        <span class="error-msg">{{ errorMsg }}</span>
    </div>
</template>
<script>
export default {
    name: "MISAFormGroup",
    props: {
        label: {
            type: String,
            required: false,
            default: "",
        },
        isRequired: {
            type: Boolean,
            required: false,
            default: false,
        },
        errorMsg: {
            type: String,
            required: false,
            default: "",
        },
    },
    data() {
        return {};
    },
};
</script>
<style></style>
