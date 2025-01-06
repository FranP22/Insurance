<script setup>
defineProps({
    policyData: Object
});
</script>

<template>
    <table>
        <tbody>
            <tr>
                <th>Policy Number</th>
                <th>Policy Amount</th>
            </tr>
            <tr v-if="policyData.length == 0">
                <th colspan="2">No policies found</th>
            </tr>
            <tr v-else v-for="item in policyData">
                <td>{{ item.policyNumber }}</td>
                <td>{{ item.policyAmount + "€" }}</td>
            </tr>
            <tr>
                <td>
                    <input type="number" id="policy-number-input" class="form-control">
                </td>
                <td>
                    <button @click="$emit('addPolicy')" class="btn btn-primary">Add</button>
                </td>
            </tr>
         </tbody>
    </table>
</template>