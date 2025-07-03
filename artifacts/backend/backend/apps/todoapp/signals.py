from .models import Usuario, Categoria, Tarefa
from django.db.models.signals import (
    pre_init,   post_init,
    pre_save,   post_save,
    pre_delete, post_delete,
    m2m_changed
)
from django.dispatch import receiver
from django.contrib.auth.models import Group

## Signals from Usuario
@receiver(pre_init, sender=Usuario)
def pre_init_usuario(sender, *args, **kwargs):
    pass

@receiver(post_init, sender=Usuario)
def post_init_usuario(sender, instance, **kwargs):
    pass

@receiver(pre_save, sender=Usuario)
def pre_save_usuario(sender, instance, raw, using, update_fields, **kwargs):
    pass

@receiver(post_save, sender=Usuario)
def post_save_usuario(sender, instance, created, raw, using, update_fields, **kwargs):
    pass

@receiver(pre_delete, sender=Usuario)
def pre_delete_usuario(sender, instance, using, **kwargs):
    pass

@receiver(post_delete, sender=Usuario)
def post_delete_usuario(sender, instance, using, **kwargs):
    pass

@receiver(m2m_changed, sender=Usuario)
def m2m_changed_usuario(sender, instance, action, reverse, model, pk_set, using, **kwargs):
    pass

## Signals from Categoria
@receiver(pre_init, sender=Categoria)
def pre_init_categoria(sender, *args, **kwargs):
    pass

@receiver(post_init, sender=Categoria)
def post_init_categoria(sender, instance, **kwargs):
    pass

@receiver(pre_save, sender=Categoria)
def pre_save_categoria(sender, instance, raw, using, update_fields, **kwargs):
    pass

@receiver(post_save, sender=Categoria)
def post_save_categoria(sender, instance, created, raw, using, update_fields, **kwargs):
    pass

@receiver(pre_delete, sender=Categoria)
def pre_delete_categoria(sender, instance, using, **kwargs):
    pass

@receiver(post_delete, sender=Categoria)
def post_delete_categoria(sender, instance, using, **kwargs):
    pass

@receiver(m2m_changed, sender=Categoria)
def m2m_changed_categoria(sender, instance, action, reverse, model, pk_set, using, **kwargs):
    pass

## Signals from Tarefa
@receiver(pre_init, sender=Tarefa)
def pre_init_tarefa(sender, *args, **kwargs):
    pass

@receiver(post_init, sender=Tarefa)
def post_init_tarefa(sender, instance, **kwargs):
    pass

@receiver(pre_save, sender=Tarefa)
def pre_save_tarefa(sender, instance, raw, using, update_fields, **kwargs):
    pass

@receiver(post_save, sender=Tarefa)
def post_save_tarefa(sender, instance, created, raw, using, update_fields, **kwargs):
    pass

@receiver(pre_delete, sender=Tarefa)
def pre_delete_tarefa(sender, instance, using, **kwargs):
    pass

@receiver(post_delete, sender=Tarefa)
def post_delete_tarefa(sender, instance, using, **kwargs):
    pass

@receiver(m2m_changed, sender=Tarefa)
def m2m_changed_tarefa(sender, instance, action, reverse, model, pk_set, using, **kwargs):
    pass
