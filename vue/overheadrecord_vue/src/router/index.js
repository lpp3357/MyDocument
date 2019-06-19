import Vue from 'vue'
import Router from 'vue-router'
import CreateClass from '@/components/CreateClass'
import CreateOverHead from '@/components/CreateOverHead'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'CreateOverHead',
      component: CreateOverHead
    },
    {
      path: '/CreateClass',
      name: 'CreateClass',
      component: CreateClass
    }
  ]
})
