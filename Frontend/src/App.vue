<script setup>
import HomeView from './components/routes/HomeView.vue';
</script>

<template>
<!--   <nav>
    <RouterLink to="/">Home</RouterLink>
  </nav> -->
  <main class="container d-flex flex-column justify-content-center align-items-center w-100" style="height: 100vh;">
    <RouterView />
  </main>
</template>
