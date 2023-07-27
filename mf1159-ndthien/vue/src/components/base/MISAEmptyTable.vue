<template>
    <tr>
        <td colspan="11" class="text-center">
            <div class="empty-data"></div>
            {{ $_MISAResource.VN.Table.EmptyData }}
        </td>
    </tr>
</template>
<script>
export default {
    name: "MISAEmptyTable",
};
</script>
<style scoped>
tr td {
    padding: 22px;
}
tr:hover td {
    background-color: #fff !important;
}

.empty-data {
    margin: 0 auto;
    background-image: url(../../assets/icon/bg-report-nodata.svg);
    background-size: contain;
    opacity: 0.6;
    width: 155px;
    height: 100px;
    background-repeat: no-repeat;
}
</style>
