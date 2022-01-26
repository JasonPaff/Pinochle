using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Pinochle.Enums;
using System.Linq;
using Pinochle.Entities;
using Pinochle.Scenes;

namespace Pinochle.Components
{
    public class NudgeOnMouseOver : Component, IUpdatable
    {
        private RectangleF _bounds;                 // entities bounds
        private RectangleF _boundsWithNudge;        // entities bounds when nudged
        private readonly Vector2 _nudgeTransform;   // size/direction of the nudge
        private Vector2 _startingPosition;          // holds the pre-nudge starting position
        private SpriteRenderer _spriteRenderer;     // sprite renderer we are nudging
        private float _startingLayerDepth;          // holds the pre-nudge layer depth
        private TwoPlayerTableScene _scene;         // scene the entity we're on belongs to
        private PlayerPinochleCard _entity;         // entity we are attached to
        public bool IsNudged { get; set; }  // flags is this components entity is nudged or not

        public NudgeOnMouseOver(Vector2 nudge)
        {
            _nudgeTransform = nudge;
        }

        /// <summary>
        /// called when the component is added to the entity
        /// store the sprite renderer and its bounds, create
        /// bounds for a nudged cards to solve an issue with
        /// the mouse leaving by the bottom of a nudged card
        /// </summary>
        public override void OnAddedToEntity()
        {
            _spriteRenderer = Entity.GetComponent<PinochleCardSprite>();
            _scene = Entity.Scene as TwoPlayerTableScene;
            _entity = Entity as PlayerPinochleCard;
            _bounds = _spriteRenderer.Bounds;
            _boundsWithNudge = _spriteRenderer.Bounds;
            _boundsWithNudge.Height += _nudgeTransform.Y;
        }
        
        /// <summary>
        /// Checks for any new nudges to begin
        /// or active nudges to end
        /// </summary>
        public void Update()
        {
            //if (!_scene.IsPlayersTurn) return;
            
            Vector2 mouse = new(Input.ScaledMousePosition.X, Input.ScaledMousePosition.Y); 
            
            CheckForNudgeBegin(mouse);

            if (!IsNudged) return; // not nudged

            CheckForNudgeEnd(mouse);
        }

        /// <summary>
        /// checks for any new nudges that will begin this frame
        /// leave if mouse is not inside the bounds or we are
        /// already nudged. Check for any other nudges active and
        /// start a nudge on the entity if none are found 
        /// </summary>
        /// <param name="mouse">mouse coords</param>
        private void CheckForNudgeBegin(Vector2 mouse)
        {
            if (!_entity.IsPlayable) return;
            
            var isInsideBounds = _bounds.Contains(mouse.X, mouse.Y);

            if (!isInsideBounds || IsNudged) return;
            
            var anyNudges = Entity.Scene.FindComponentsOfType<NudgeOnMouseOver>()
                .Any(i => i.IsNudged);

            if (!anyNudges) NudgeBegin();
        }

        /// <summary>
        /// checks for an active nudge and whether it should end
        /// confirm a nudge then check bounds to see if mouse has left
        /// if it has call NudgeEnd()
        /// </summary>
        /// <param name="mouse">mouse coords</param>
        private void CheckForNudgeEnd(Vector2 mouse)
        {
            if (!_boundsWithNudge.Contains(mouse)) // still in bounds
                NudgeEnd();
        }
        
        /// <summary>
        /// 'Nudge' a card forward by some amount 
        /// flag nudge, store starting values, update values to nudge values
        /// </summary>
        private void NudgeBegin()
        {            
            IsNudged = true;
            _startingPosition = _spriteRenderer.Entity.Position;
            _startingLayerDepth = _spriteRenderer.LayerDepth;
            _spriteRenderer.SetLayerDepth(0.01f);
            var position = _spriteRenderer.Entity.Position += _nudgeTransform;
            _spriteRenderer.Entity.SetPosition(position);
        }

        /// <summary>
        /// resets any active pinochle card nudges
        /// load saved pre nudge values
        /// remove nudge flag
        /// </summary>
        private void NudgeEnd()
        {
            _spriteRenderer.Entity.SetPosition(_startingPosition);
            _spriteRenderer.SetLayerDepth(_startingLayerDepth);
            IsNudged = false;
        }
    }
}