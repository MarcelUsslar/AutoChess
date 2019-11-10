using Zenject;
using _Scripts.Utility;

namespace _Scripts.PlayAreas
{
    public class FieldController
    {
        public class Factory : PlaceholderFactory<IFieldView, FieldController>
        { }

        public FieldController(IFieldView view, IFieldConfig config, IDisposer disposer)
        {
            view.FieldMaterial = config.DefaultMaterial;

            view.OnPointerEnterAsObservable
                .Subscribe(() => view.FieldMaterial = config.EnteredMaterial)
                .AddToDisposer(disposer);

            view.OnPointerExitAsObservable
                .Subscribe(() => view.FieldMaterial = config.DefaultMaterial)
                .AddToDisposer(disposer);
        }
    }
}