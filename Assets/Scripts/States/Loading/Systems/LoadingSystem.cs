using alicewithalex.Data;
using alicewithalex.UI;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Systems
{
    //public class LoadingSystem : StateSystemWithScreen<LoadingStateData, LoadingUIScreen>
    //{
    //    public override State State => State.Loading;

    //    public override void StateEnter()
    //    {
    //        base.StateEnter();
    //        Camera.onPostRender += OnPostRender;
    //        StateData.LoadingEventProvider.OnFadeValueChanged += ChangeOpacity;
    //        StateData.LoadingEventProvider.OnLoadingStateChanged += Screen.ToggleProgress;
    //        StateData.LoadingEventProvider.OnLoadingProgressChanged += Screen.UpdateProgress;
    //    }

    //    public override void StateExit()
    //    {
    //        base.StateExit();
    //        Camera.onPostRender -= OnPostRender;
    //        StateData.LoadingEventProvider.OnFadeValueChanged -= ChangeOpacity;
    //        StateData.LoadingEventProvider.OnLoadingStateChanged -= Screen.ToggleProgress;
    //        StateData.LoadingEventProvider.OnLoadingProgressChanged -= Screen.UpdateProgress;
    //    }

    //    private void ChangeOpacity(float value)
    //    {
    //        StateData.OverlayMaterial.SetColor("_Color", new Color(0, 0, 0, value));
    //    }

    //    #region OpenGL

    //    private void Point(float x, float y)
    //    {
    //        GL.TexCoord2(x, y);
    //        GL.Vertex3(x, y, -1);
    //    }

    //    private void OnPostRender(Camera cam)
    //    {
    //        StateData.OverlayMaterial.SetPass(0);
    //        GL.PushMatrix();
    //        GL.LoadIdentity();
    //        GL.LoadProjectionMatrix(Matrix4x4.Ortho(0, 1, 0, 1, 0, 1));
    //        GL.Begin(GL.QUADS);
    //        Point(0, 0);
    //        Point(0, 1);
    //        Point(1, 1);
    //        Point(1, 0);
    //        GL.End();
    //        GL.PopMatrix();
    //    }

    //    #endregion

    //}
}