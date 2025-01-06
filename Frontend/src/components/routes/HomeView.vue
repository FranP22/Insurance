<script setup>
import { getAllPartners, getPartnerByNumber, getPartnerPolicies } from '@/scripts/api/partner/partner';
import { onMounted, ref } from 'vue';
import HomeTable from './homeview/HomeTable.vue';
import { useRoute, useRouter } from 'vue-router';

const api = "https://localhost:7079";

const partnerData = ref({})
const dataLoaded = ref(false)

const insertedPartner = ref(0);

const router = useRouter();
const route = useRoute();

async function loadData(){
    var data = await getAllPartners(api);
    partnerData.value = data;
    dataLoaded.value = true;
}

function openAddPartner(){
    router.push({ path: '/newpartner' })
}

function partnerDetails(number){
    router.push({ path: '/partner/' + number })
}

onMounted(() => {
    loadData();

    insertedPartner.value = route.params.number;
})
</script>

<template>
    <div class="w-100 d-flex justify-content-left align-items-center p-3">
        <button @click="openAddPartner" class="btn btn-primary">Add Partner</button>
    </div>
    <HomeTable v-if="dataLoaded" :partnerData="partnerData" @partnerDetails="partnerDetails" :insertedPartner="insertedPartner"></HomeTable>
</template>