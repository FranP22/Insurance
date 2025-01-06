<script setup>
import { getPartnerByNumber, getPartnerPolicies } from '@/scripts/api/partner/partner';
import { onMounted, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import PartnerDetails from './detailsview/PartnerDetails.vue';
import PolicyDetails from './detailsview/PolicyDetails.vue';
import { Policy } from '@/scripts/api/policy/policy-model';
import { addPolicy } from '@/scripts/api/policy/policy';

const api = "https://localhost:7079";

const partner = ref({});
const policies = ref([]);

const router = useRouter();
const route = useRoute();

async function addNewPolicy(){
    const number = route.params.number;
    if(number){
        var amount = document.getElementById("policy-number-input").value;
        if (isNaN(amount) || amount === '') return;
        
        var policy = new Policy("0", number.toString(), amount);
        var result = await addPolicy(api, policy);
        getPartnerDetails(number);
    }
}

async function getPartnerDetails(number){
    //dataLoaded.value = false;

    var partnerResult = await getPartnerByNumber(api, number);
    var policiesResult = await getPartnerPolicies(api, number);

    partner.value = partnerResult.data;
    policies.value = policiesResult.data;

    //dataLoaded.value = true;
}

onMounted(() => {
    const number = route.params.number;
    if (number) {
        getPartnerDetails(number);
    } else {
        console.log("Partner number is missing");
        //dataLoaded.value = true;
    }
})

function back(){
    router.back();
}
</script>

<template>
    <div class="w-50 d-flex justify-content-left align-items-center p-3">
        <button @click="back" class="btn btn-secondary">Back</button>
    </div>
    <PartnerDetails v-if="partner" :partnerData="partner" class="my-5"></PartnerDetails>
    <PolicyDetails v-if="policies" :policyData="policies" @addPolicy="addNewPolicy"></PolicyDetails>
</template>