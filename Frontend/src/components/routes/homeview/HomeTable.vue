<script setup>
import HomeTableRow from './HomeTableRow.vue';

defineProps({
    partnerData: Object,
    insertedPartner: String
})
</script>

<template>
    <table class="w-100">
        <tbody>
            <tr>
                <td>Partner Number</td>
                <td>Full Name</td>
                <td>Croatian Pin</td>
                <td>Partner Type Id</td>
                <td>Created At UTC</td>
                <td>Is Foreign</td>
                <td>Gender</td>
            </tr>

            <HomeTableRow v-for="item in partnerData.data" :partnerDataRow="item" @click="$emit('partnerDetails', item.partnerNumber)" :insertedPartner="insertedPartner"></HomeTableRow>
        </tbody>
    </table>
</template>

<style>
.newely-inserted > *{
    font-weight: bolder;
}
</style>