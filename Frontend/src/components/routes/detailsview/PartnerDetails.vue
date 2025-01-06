<script setup>
import { onMounted } from 'vue';

defineProps({
    partnerData: Object
});

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
</script>

<template>
    <table>
        <tbody>
            <tr>
                <th>Full Name</th>
                <td>{{ partnerData.firstName + " " + partnerData.lastName }}</td>
            </tr>
            <tr>
                <th>Address</th>
                <td>{{ partnerData.address }}</td>
            </tr>
            <tr>
                <th>Partner Number</th>
                <td>{{ partnerData.partnerNumber }}</td>
            </tr>
            <tr>
                <th>Croatian Pin</th>
                <td>{{ partnerData.croatianPin }}</td>
            </tr>
            <tr>
                <th>Partner Type Id</th>
                <td>{{ getPartnerType(partnerData.partnerTypeId) }}</td>
            </tr>
            <tr>
                <th>Created At UTC</th>
                <td>{{ partnerData.createdAtUtc }}</td>
            </tr>
            <tr>
                <th>Created By User</th>
                <td>{{ partnerData.createdByUser }}</td>
            </tr>
            <tr>
                <th>Is Foreign</th>
                <td>{{ partnerData.isForeign }}</td>
            </tr>
            <tr>
                <th>External Code</th>
                <td>{{ partnerData.externalCode }}</td>
            </tr>
            <tr>
                <th>Gender</th>
                <td>{{ partnerData.gender }}</td>
            </tr>
         </tbody>
    </table>
</template>