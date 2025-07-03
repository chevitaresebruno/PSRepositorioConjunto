from django.apps import AppConfig

class ToDoAppConfig(AppConfig):
    name  = 'apps.todoapp'
    label = 'apps_todoapp'

    def ready(self):
        import apps.todoapp.signals
