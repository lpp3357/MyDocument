import Vue from 'vue'
import Router from 'vue-router'
import CreateClass from '@/components/CreateClass'
import CreateOverHead from '@/components/CreateOverHead'
import QueryOverHead from '@/components/QueryOverHead'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'CreateOverHead',
      component: CreateOverHead
    },
    {
      path: '/QueryOverHead',
      name: 'QueryOverHead',
      component: QueryOverHead
    },
    {
      path: '/CreateClass',
      name: 'CreateClass',
      component: CreateClass
    }
  ]
})
