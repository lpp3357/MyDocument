import Vue from 'vue'
import Router from 'vue-router'
import CreateClass from '@/components/CreateClass'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'CreateClass',
      component: CreateClass
    }
  ]
})
