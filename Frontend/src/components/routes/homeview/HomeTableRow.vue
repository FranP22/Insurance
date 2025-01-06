<script setup>
import { getPartnerPolicies } from '@/scripts/api/partner/partner';
import { onMounted, ref } from 'vue';

const props = defineProps({
    partnerDataRow: Object,
    insertedPartner: String
})

const isMarked = ref(false);
const fullName = ref("");

function getPartnerType(id){
    switch(id){
        case 1:
            return "Personal";
        case 2:
            return "Legal";
        default:
            return "";
    }
}

function policySum(policies){
    var count = 0;
    policies.forEach(item => {
        count += item.policyAmount;
    });

    return count;
}

onMounted(async () => {
    if(props.partnerDataRow){
        var policies = await getPartnerPolicies('https://localhost:7079', props.partnerDataRow.partnerNumber);
        fullName.value = props.partnerDataRow.firstName + " " + props.partnerDataRow.lastName;
        if(policies.data.length >= 5 || policySum(policies.data) >= 5000){
            fullName.value = "* " + fullName.value;
        }
    }
})
</script>

<template>
    <tr :class="[insertedPartner == partnerDataRow.partnerNumber ? 'newely-inserted' : '']" class="partner-row">
        <td>{{ partnerDataRow.partnerNumber }}</td>
        <td>{{ fullName }}</td>
        <td>{{ partnerDataRow.croatianPin }}</td>
        <td>{{ getPartnerType(partnerDataRow.partnerTypeId) }}</td>
        <td>{{ partnerDataRow.createdAtUtc }}</td>
        <td>{{ partnerDataRow.isForeign }}</td>
        <td>{{ partnerDataRow.gender }}</td>
    </tr>
</template>

<style>
.partner-row:hover{
    background-color: lightgray;
}
</style>