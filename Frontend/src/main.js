//import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'

import { createRouter, createWebHistory } from 'vue-router'

import HomeView from './components/routes/HomeView.vue'
import DetailsView from './components/routes/DetailsView.vue'
import NewPartner from './components/routes/NewPartner.vue'

const routes = [
  { path: '/', component: HomeView, name: "Home" },
  { path: '/new/:number', component: HomeView },
  { path: '/partner/:number', component: DetailsView, name: "Details" },
  { path: '/newpartner', component: NewPartner, name: "NewPartner" },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

createApp(App)
.use(router)
.mount('#app')
