<template>
  <div class="jobs">
    <router-link :to="{name: 'JobPage', params: {id: jobs.id}}">
      <h4 @click="setActive">
        {{ jobs.title }}
      </h4>
    </router-link>
    <h5>{{ jobs.location }}</h5>
  </div>
</template>

<script>
import { computed } from 'vue'
import { jobService } from '../../services/JobService'
export default {
  name: 'Jobs',
  props: ['jobProp'],
  setup(props) {
    return {
      setActive() {
        jobService.setActive(this.jobs)
      },
      jobs: computed(() => props.jobProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
